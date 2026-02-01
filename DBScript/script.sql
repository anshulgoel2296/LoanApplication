-- User Table
CREATE TABLE users (
    id INT IDENTITY(1,1) PRIMARY KEY,
    first_name NVARCHAR(50) NOT NULL,
    last_name NVARCHAR(50) NOT NULL,
    email NVARCHAR(320) NOT NULL,
    contact_number BIGINT NULL,
    created_datetime DATETIME2(3) NOT NULL DEFAULT SYSUTCDATETIME(),

    CONSTRAINT UQ_users_email UNIQUE (email)
);

-- Loan Type
CREATE TABLE dbo.loan_types (
    loan_id INT IDENTITY(1,1) PRIMARY KEY,
    loan_code VARCHAR(50) NOT NULL,
    description NVARCHAR(255) NULL,
    CONSTRAINT UQ_loan_types_code UNIQUE (loan_code)
);

-- Application Status
CREATE TABLE dbo.application_status (
    status_id INT IDENTITY(1,1) PRIMARY KEY,
    status_code VARCHAR(30) NOT NULL,
    description NVARCHAR(255) NULL,
    is_update_enabled BIT NOT NULL DEFAULT 0,
    CONSTRAINT UQ_application_status_code UNIQUE (status_code)
);


-- Loan Application Table
CREATE TABLE dbo.loan_applications (
    id                  INT IDENTITY(1,1) PRIMARY KEY,
    user_id             INT NOT NULL,
    loan_type_id        INT NOT NULL,
    current_status_id   INT NOT NULL,
    previous_status_id   INT NOT NULL,
    loan_amount         DECIMAL(18,2) NOT NULL
        CONSTRAINT CK_loan_amount_positive CHECK (loan_amount > 0),
    created_datetime          DATETIME2(3) NOT NULL DEFAULT SYSUTCDATETIME(),
    updated_datetime          DATETIME2(3) NOT NULL DEFAULT SYSUTCDATETIME(),

    CONSTRAINT FK_loan_applications_user
        FOREIGN KEY (user_id)
        REFERENCES dbo.users(id),

    CONSTRAINT FK_loan_applications_loan_type
        FOREIGN KEY (loan_type_id)
        REFERENCES dbo.loan_types(loan_id),

    CONSTRAINT FK_loan_applications_status
        FOREIGN KEY (current_status_id)
        REFERENCES dbo.application_status(status_id),

    -- Only one application per user per loan type
    CONSTRAINT UQ_user_loan_type UNIQUE (user_id, loan_type_id)
);
