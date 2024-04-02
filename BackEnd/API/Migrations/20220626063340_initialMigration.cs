using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
        //protected override void Up(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.EnsureSchema(
        //        name: "Accounts");

        //    migrationBuilder.EnsureSchema(
        //        name: "Membership");

        //    migrationBuilder.CreateTable(
        //        name: "'Total JV$'",
        //        columns: table => new
        //        {
        //            SlNo = table.Column<double>(name: "Sl No", type: "float", nullable: true),
        //            Year = table.Column<double>(type: "float", nullable: true),
        //            Month = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
        //            AccountHead = table.Column<string>(name: "Account Head", type: "nvarchar(255)", maxLength: 255, nullable: true),
        //            SubAccountExpenses = table.Column<string>(name: "Sub Account / Expenses", type: "nvarchar(255)", maxLength: 255, nullable: true),
        //            Remarks = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
        //            Debit = table.Column<double>(type: "float", nullable: true),
        //            Credit = table.Column<double>(type: "float", nullable: true),
        //            VoucherNo = table.Column<double>(name: "Voucher No", type: "float", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //        });

        //    //migrationBuilder.CreateTable(
        //    //    name: "AccountHead",
        //    //    schema: "Accounts",
        //    //    columns: table => new
        //    //    {
        //    //        TenentID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
        //    //        LocationID = table.Column<int>(type: "int", nullable: false),
        //    //        HeadID = table.Column<int>(type: "int", nullable: false),
        //    //        Family_ID = table.Column<int>(type: "int", nullable: false),
        //    //        HeadCode = table.Column<int>(type: "int", nullable: false),
        //    //        HeadName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
        //    //        ArabicHeadName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
        //    //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
        //    //        crupid = table.Column<long>(type: "bigint", nullable: true),
        //    //        BalanceAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValueSql: "((0))")
        //    //    },
        //    //    constraints: table =>
        //    //    {
        //    //        table.PrimaryKey("PK_AccountHead", x => new { x.TenentID, x.LocationID, x.HeadID });
        //    //    });

        //    //migrationBuilder.CreateTable(
        //    //    name: "AccountTypes",
        //    //    schema: "Accounts",
        //    //    columns: table => new
        //    //    {
        //    //        AccountTypeID = table.Column<int>(type: "int", nullable: false),
        //    //        AccountTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "(N'Name')"),
        //    //        ArabicAccountTypeName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
        //    //    },
        //    //    constraints: table =>
        //    //    {
        //    //        table.PrimaryKey("PK_AccountTypes", x => x.AccountTypeID);
        //    //    });

        //    //migrationBuilder.CreateTable(
        //    //    name: "ChequeBooks",
        //    //    schema: "Accounts",
        //    //    columns: table => new
        //    //    {
        //    //        TenentID = table.Column<int>(type: "int", nullable: false),
        //    //        LocationID = table.Column<int>(type: "int", nullable: false),
        //    //        ChequeBookID = table.Column<int>(type: "int", nullable: false),
        //    //        Account_ID = table.Column<int>(type: "int", nullable: true),
        //    //        FromChequeNo = table.Column<int>(type: "int", nullable: true),
        //    //        ToChequeNo = table.Column<int>(type: "int", nullable: true),
        //    //        TotalCheques = table.Column<int>(type: "int", nullable: true),
        //    //        UsedCheques = table.Column<int>(type: "int", nullable: true),
        //    //        CreatedBy = table.Column<int>(type: "int", nullable: true),
        //    //        CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //    //        UpdatedBy = table.Column<int>(type: "int", nullable: true),
        //    //        UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //    //        EntryDate = table.Column<DateTime>(type: "date", nullable: true)
        //    //    },
        //    //    constraints: table =>
        //    //    {
        //    //        table.PrimaryKey("PK_ChequeBooks", x => new { x.TenentID, x.LocationID, x.ChequeBookID });
        //    //    });

        //    //migrationBuilder.CreateTable(
        //    //    name: "COA",
        //    //    schema: "Accounts",
        //    //    columns: table => new
        //    //    {
        //    //        TenentID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
        //    //        locationID = table.Column<int>(type: "int", nullable: false),
        //    //        AccountID = table.Column<int>(type: "int", nullable: false),
        //    //        Family_ID = table.Column<int>(type: "int", nullable: true),
        //    //        Head_ID = table.Column<int>(type: "int", nullable: false),
        //    //        SubHead_ID = table.Column<int>(type: "int", nullable: true),
        //    //        AccountNumber = table.Column<int>(type: "int", nullable: false),
        //    //        AccountName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
        //    //        ArabicAccountName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
        //    //        OtherAccountName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
        //    //        AccountType_ID = table.Column<int>(type: "int", nullable: false),
        //    //        IsActive = table.Column<bool>(type: "bit", nullable: false),
        //    //        CreatedBy = table.Column<int>(type: "int", nullable: true),
        //    //        CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //    //        UpdatedBy = table.Column<int>(type: "int", nullable: true),
        //    //        UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //    //        crupid = table.Column<long>(type: "bigint", nullable: true),
        //    //        BankAccountNo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //    //        SubSubHead_ID = table.Column<int>(type: "int", nullable: true)
        //    //    },
        //    //    constraints: table =>
        //    //    {
        //    //        table.PrimaryKey("PK_COA", x => new { x.TenentID, x.locationID, x.AccountID });
        //    //    });

        //    //migrationBuilder.CreateTable(
        //    //    name: "CostCenters",
        //    //    schema: "Accounts",
        //    //    columns: table => new
        //    //    {
        //    //        TenentID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
        //    //        locationID = table.Column<int>(type: "int", nullable: false),
        //    //        CostCenterID = table.Column<int>(type: "int", nullable: false),
        //    //        CostCenterNumber = table.Column<int>(type: "int", nullable: true),
        //    //        CostCenterName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
        //    //        ArabicCostCenterName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
        //    //        OtherCostCenterName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
        //    //        IsActive = table.Column<bool>(type: "bit", nullable: true),
        //    //        CreatedBy = table.Column<int>(type: "int", nullable: true),
        //    //        CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //    //        UpdatedBy = table.Column<int>(type: "int", nullable: true),
        //    //        UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //    //        crupid = table.Column<long>(type: "bigint", nullable: true)
        //    //    },
        //    //    constraints: table =>
        //    //    {
        //    //        table.PrimaryKey("PK_CostCenters", x => new { x.TenentID, x.locationID, x.CostCenterID });
        //    //    });

        //    //migrationBuilder.CreateTable(
        //    //    name: "CRUP_MST",
        //    //    columns: table => new
        //    //    {
        //    //        TENANT_ID = table.Column<int>(type: "int", nullable: false),
        //    //        LocationID = table.Column<int>(type: "int", nullable: false),
        //    //        CRUP_ID = table.Column<long>(type: "bigint", nullable: false),
        //    //        MySerial = table.Column<int>(type: "int", nullable: true),
        //    //        MENU_ID = table.Column<int>(type: "int", nullable: true),
        //    //        PHYSICALLOCID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //    //        ActivityNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //    //        CREATED_BY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
        //    //        CREATED_DT = table.Column<DateTime>(type: "datetime", nullable: false),
        //    //        UPDATED_BY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //    //        UPDATED_DT = table.Column<DateTime>(type: "datetime", nullable: true)
        //    //    },
        //    //    constraints: table =>
        //    //    {
        //    //        table.PrimaryKey("PK_ERP_CREATEUPDATE_MST", x => new { x.TENANT_ID, x.LocationID, x.CRUP_ID });
        //    //    });

        //    migrationBuilder.CreateTable(
        //        name: "CRUPAudit",
        //        columns: table => new
        //        {
        //            TENANT_ID = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "((18))"),
        //            LocationID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: false),
        //            MySerial = table.Column<int>(type: "int", nullable: false),
        //            AuditNo = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            AuditType = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
        //            TableName = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
        //            FieldName = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
        //            OldValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            NewValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            UpdateUserName = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
        //            CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            CreatedUserName = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_CRUPAuditAudit", x => new { x.TENANT_ID, x.LocationID, x.CRUP_ID, x.MySerial, x.AuditNo });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "DeletedVoucher",
        //        schema: "Accounts",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false),
        //            locationID = table.Column<int>(type: "int", nullable: false),
        //            VoucherID = table.Column<int>(type: "int", nullable: false),
        //            VoucherCode = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
        //            FPeriod_ID = table.Column<int>(type: "int", nullable: false),
        //            VoucherType_ID = table.Column<int>(type: "int", nullable: false),
        //            Account_ID = table.Column<int>(type: "int", nullable: true),
        //            VoucherDate = table.Column<DateTime>(type: "date", nullable: false),
        //            IsPosted = table.Column<bool>(type: "bit", nullable: false),
        //            Narrations = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
        //            ReceiverName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
        //            ReferenceNo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            CostCenter_ID = table.Column<int>(type: "int", nullable: true),
        //            UpdatedBy = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            CreatedBy = table.Column<int>(type: "int", nullable: true),
        //            CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            crupid = table.Column<long>(type: "bigint", nullable: true),
        //            DeletedBy = table.Column<int>(type: "int", nullable: true),
        //            DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_DeletedVoucher", x => new { x.TenentID, x.locationID, x.VoucherID });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "DetailedEmployee",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false),
        //            LocationID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
        //            employeeID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
        //            ContractType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            PFID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //            SubscribedDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            AgreedSubAmount = table.Column<decimal>(type: "numeric(18,3)", nullable: true),
        //            ReSubscribed = table.Column<DateTime>(type: "datetime", nullable: true),
        //            EmployeeType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "(N'1')", comment: "1= Employee, 2= Non Employee"),
        //            ArabicName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //            EnglishName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //            job_title_code = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))", comment: "Coming from RefTable RefSubType='Role'"),
        //            job_title_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //            Department = table.Column<int>(type: "int", nullable: true, comment: "Coming from RefTable RefSubType='Department'"),
        //            Department_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //            emp_gender = table.Column<short>(type: "smallint", nullable: true),
        //            emp_birthday = table.Column<DateTime>(type: "datetime", nullable: true),
        //            emp_marital_status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //            salary = table.Column<decimal>(type: "numeric(18,3)", nullable: true),
        //            emp_work_telephone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((1))"),
        //            emp_work_email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((1))"),
        //            MobileNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
        //            Next2KinName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //            Next2KinMobNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
        //            nation_code = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((126))", comment: "Nationality Code from tblcountry"),
        //            nation_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //            emp_cid_num = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, defaultValueSql: "((1))"),
        //            emp_paci_num = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, defaultValueSql: "((1))"),
        //            emp_other_id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, defaultValueSql: "((1))"),
        //            emp_status = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
        //            joined_date = table.Column<DateTime>(type: "datetime", nullable: true),
        //            End_date = table.Column<DateTime>(type: "datetime", nullable: true),
        //            termination_id = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
        //            subscription_date = table.Column<DateTime>(type: "datetime", nullable: true),
        //            ReSubscriped_date = table.Column<DateTime>(type: "datetime", nullable: true),
        //            LoanAct = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            HajjAct = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            PersLoanAct = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            OtherAct1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account"),
        //            OtherAct2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account"),
        //            OtherAct3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account"),
        //            OtherAct4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account"),
        //            OtherAct5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account"),
        //            emp_street1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, defaultValueSql: "((1))"),
        //            emp_street2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, defaultValueSql: "((1))"),
        //            city_code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((1))"),
        //            coun_code = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
        //            Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
        //            userID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            ActiveDirectoryID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            MainHRRoleID = table.Column<int>(type: "int", nullable: true, comment: "Coming from RefTable RefSubType='Role'"),
        //            EmployeeLoginID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            EmployeePassword = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
        //            Active = table.Column<bool>(type: "bit", nullable: true),
        //            Deleted = table.Column<bool>(type: "bit", nullable: true),
        //            DateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
        //            DeviceID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((0))"),
        //            UploadDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            Uploadby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            SyncDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            Syncby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            SynID = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_tbl_Employee", x => new { x.TenentID, x.LocationID, x.employeeID });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "DetailedEmployee_Import",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false),
        //            LocationID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
        //            employeeID = table.Column<int>(type: "int", nullable: false),
        //            IMPORTDATE = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
        //            PFID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //            EmployeeType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "(N'1')", comment: "1= Employee, 2= Non Employee"),
        //            ArabicName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //            EnglishName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //            job_title_code = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))", comment: "Coming from RefTable RefSubType='Role'"),
        //            job_title_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //            Department = table.Column<int>(type: "int", nullable: true, comment: "Coming from RefTable RefSubType='Department'"),
        //            Department_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //            emp_gender = table.Column<short>(type: "smallint", nullable: true),
        //            emp_birthday = table.Column<DateTime>(type: "datetime", nullable: true),
        //            emp_marital_status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //            salary = table.Column<decimal>(type: "numeric(18,3)", nullable: true),
        //            emp_work_telephone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((1))"),
        //            emp_work_email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((1))"),
        //            MobileNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
        //            Next2KinName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //            Next2KinMobNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
        //            nation_code = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((126))", comment: "Nationality Code from tblcountry"),
        //            emp_cid_num = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, defaultValueSql: "((1))"),
        //            emp_paci_num = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, defaultValueSql: "((1))"),
        //            emp_other_id = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
        //            emp_status = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
        //            joined_date = table.Column<DateTime>(type: "datetime", nullable: true),
        //            End_date = table.Column<DateTime>(type: "datetime", nullable: true),
        //            subscription_date = table.Column<DateTime>(type: "datetime", nullable: true),
        //            ReSubscriped_date = table.Column<DateTime>(type: "datetime", nullable: true),
        //            LoanAct = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            HajjAct = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            PersLoanAct = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            OtherAct1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account"),
        //            OtherAct2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account"),
        //            OtherAct3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account"),
        //            OtherAct4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account"),
        //            OtherAct5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account"),
        //            emp_street1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, defaultValueSql: "((1))"),
        //            emp_street2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, defaultValueSql: "((1))"),
        //            city_code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((1))"),
        //            coun_code = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
        //            termination_id = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
        //            Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
        //            userID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            ActiveDirectoryID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            MainHRRoleID = table.Column<int>(type: "int", nullable: true, comment: "Coming from RefTable RefSubType='Role'"),
        //            Studen_LoginID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            PASSWORD = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
        //            Active = table.Column<bool>(type: "bit", nullable: true),
        //            Deleted = table.Column<bool>(type: "bit", nullable: true),
        //            DateTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
        //            DeviceID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((0))"),
        //            UploadDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            Uploadby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            SyncDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            Syncby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            SynID = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_DetailedEmployee_Import", x => new { x.TenentID, x.LocationID, x.employeeID });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "DrCrTemplate",
        //        schema: "Accounts",
        //        columns: table => new
        //        {
        //            TemplateID = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            TemplateName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
        //            ArabicTemplateName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
        //            IsDrNote = table.Column<bool>(type: "bit", nullable: true),
        //            Account_ID = table.Column<int>(type: "int", nullable: true),
        //            Remarks = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
        //            CreatedBy = table.Column<int>(type: "int", nullable: true),
        //            CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            UpdatedBy = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK__DrCrTemp__F87ADD07FC51001D", x => x.TemplateID);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "FAAccountGroup",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false),
        //            LocationId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
        //            ActGroupId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
        //            GLSL = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false, comment: "GL/SL"),
        //            InternalGroupId = table.Column<int>(type: "int", nullable: false, comment: "coming from REFID from RefType=ACT RefSubtype=Group"),
        //            DefaultCC = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //            GroupUnder = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "The Main Group is from the same Table"),
        //            GroupType = table.Column<int>(type: "int", nullable: false, comment: "REFID From the RefTable REFTYPE=AccountTyp REFSUBTYPE=Type (Assets, Liabilities, Equity, Revenue, Expenses)"),
        //            GroupSubType = table.Column<int>(type: "int", nullable: false, comment: "REFID From the RefTable REFTYPE=AccountTyp REFSUBTYPE=SubType based upon above choosen Account Type this sub type will be displayed"),
        //            GroupNatureType = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true, comment: "1=Income, 2= Expenditure"),
        //            GroupDesc1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
        //            GroupDesc2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //            GroupDesc3 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //            DisplayOrder = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))", comment: ""),
        //            EffectGrossProfit = table.Column<int>(type: "int", nullable: false, comment: "1=Yes/ 0=No"),
        //            IsDefault = table.Column<bool>(type: "bit", nullable: true),
        //            IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
        //            CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "((0))", comment: "1=Yes / 0=No"),
        //            CreatedById = table.Column<int>(type: "int", nullable: false),
        //            UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
        //            UpdatedById = table.Column<int>(type: "int", nullable: false),
        //            Active = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: true),
        //            CUSERID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_AccountGroup", x => new { x.TenentID, x.LocationId, x.ActGroupId });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "FAActIntegSetup",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false),
        //            LocationId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
        //            ActIntegrationID = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false, defaultValueSql: "((0))", comment: "1=CostOSales,2=Sales,3=Items Related Expenses"),
        //            MYSYSNAME = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: false, comment: "tblsystems.mysysname for the exist unique tbltranssubtype.mysysname record in tbltranssubtype"),
        //            transid = table.Column<int>(type: "int", nullable: false, comment: "tbltranssubtype.Transid for the Selected above System"),
        //            transsubid = table.Column<int>(type: "int", nullable: false, comment: "tbltranssubtype.Transsubid for the Selected above System"),
        //            AccountID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "From the FASLAccount.SLAccountID to be used here where the type of the account to be decided like expense etc"),
        //            GroupID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "The  FAAcountGroup.ActGroupID to be used as default yet no action needed from this"),
        //            FromItemId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "From the MYPRODID.TBLPRODUCT incase of one Item than From & To remain Same"),
        //            ToItemId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "From the MYPRODID.TBLPRODUCT incase of one Item than From & To remain Same"),
        //            FromCatSubID = table.Column<int>(type: "int", nullable: false, comment: "tblCategory having self Join"),
        //            ToCatSubID = table.Column<int>(type: "int", nullable: false, comment: "tblCategory having self Join"),
        //            DefaultCC = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "Cost Center yet no drop down available but for the future use"),
        //            IntegrationDesc1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
        //            IntegrationDesc2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //            IntegrationDesc3 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //            Consolidation = table.Column<bool>(type: "bit", nullable: true, comment: "Cost Center yet no drop down available but for the future use"),
        //            ConsolidationType = table.Column<string>(type: "nchar(2)", fixedLength: true, maxLength: 2, nullable: false, defaultValueSql: "((0))", comment: "Consolidation MO=Monthly / WK=Weekly / DA=Daily / YR=Yearly / PR=Once in the Period"),
        //            CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "((0))", comment: "Consolidation 1=Yes / 0=No"),
        //            CreatedById = table.Column<int>(type: "int", nullable: false),
        //            UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
        //            UpdatedById = table.Column<int>(type: "int", nullable: false),
        //            Active = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_FAActIntegSetup", x => new { x.TenentID, x.LocationId, x.transid, x.MYSYSNAME, x.transsubid, x.ActIntegrationID, x.AccountID });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "FAActPredGroup",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false),
        //            LocationId = table.Column<int>(type: "int", nullable: false),
        //            ActPredGroupId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "User will enter and not allowed to change any predefined here it is fixed"),
        //            Description1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //            Description2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //            Description3 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //            GroupUnder = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            GLSL = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true, comment: "GL/SL"),
        //            InternalGroupId = table.Column<int>(type: "int", nullable: true, comment: "coming from REFID from RefType=ACT RefSubtype=Group"),
        //            GroupType = table.Column<int>(type: "int", nullable: true, comment: "REFID From the RefTable REFTYPE=AccountTyp REFSUBTYPE=Type (Assets, Liabilities, Equity, Revenue, Expenses)"),
        //            GroupSubType = table.Column<int>(type: "int", nullable: true, comment: "REFID From the RefTable REFTYPE=AccountTyp REFSUBTYPE=SubType based upon above choosen Account Type this sub type will be displayed"),
        //            GroupNatureType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //            LeftRight = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: true),
        //            DefaultCC = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //            DisplayOrder = table.Column<int>(type: "int", nullable: true),
        //            Active = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: true),
        //            CUSERID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "((0))", comment: "1=Yes / 0=No"),
        //            CreatedById = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            UpdatedById = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_FAActPredGroup", x => new { x.TenentID, x.LocationId, x.ActPredGroupId });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "FACashBankMaster",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false),
        //            LocationId = table.Column<int>(type: "int", nullable: false),
        //            AcountId = table.Column<int>(type: "int", nullable: false),
        //            PreDefinedAccount = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
        //            ActGroupId = table.Column<int>(type: "int", nullable: true),
        //            SortingOrder = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            AccountName1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
        //            AccountName2 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
        //            AccountName3 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
        //            ActType = table.Column<int>(type: "int", nullable: true),
        //            AnalysisType = table.Column<int>(type: "int", nullable: true),
        //            VoucherNo = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
        //            VoucherDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            VoucherMiti = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
        //            LedgerId = table.Column<int>(type: "int", nullable: true),
        //            CurrentBalance = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            ChequeNo = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
        //            ChequeDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            CurrencyId = table.Column<int>(type: "int", nullable: true),
        //            Rate = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            Remarks = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
        //            CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            CreatedById = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            UpdatedById = table.Column<int>(type: "int", nullable: true),
        //            IsApproved = table.Column<bool>(type: "bit", nullable: true),
        //            ApprovedDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            ApprovedBy = table.Column<int>(type: "int", nullable: true),
        //            DocId = table.Column<int>(type: "int", nullable: true),
        //            FYid = table.Column<int>(type: "int", nullable: true),
        //            BranchId = table.Column<int>(type: "int", nullable: true),
        //            IsDeleted = table.Column<bool>(type: "bit", nullable: true),
        //            ChequeMiti = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_FACashBankMaster", x => new { x.TenentID, x.LocationId, x.AcountId });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "FAChequeBook",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false),
        //            ChequeID = table.Column<int>(type: "int", nullable: false),
        //            BankID = table.Column<int>(type: "int", nullable: true),
        //            ChequeName1 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
        //            ChequeName2 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
        //            ChequeName3 = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
        //            Amount = table.Column<int>(type: "int", nullable: true),
        //            Dated = table.Column<DateTime>(type: "datetime", nullable: true),
        //            DateOutFromBank = table.Column<DateTime>(type: "datetime", nullable: true),
        //            COMPID = table.Column<int>(type: "int", nullable: true),
        //            Remarks = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
        //            ContactMyID = table.Column<int>(type: "int", nullable: true),
        //            SWITCH1 = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
        //            ACTIVE = table.Column<bool>(type: "bit", nullable: true),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: true),
        //            SyncDate = table.Column<DateTime>(type: "datetime", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_FAChequeBook", x => new { x.TenentID, x.ChequeID });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "FACostCenter",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false),
        //            LocationId = table.Column<int>(type: "int", nullable: false),
        //            CostCenterID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "User will enter and not allowed to change any predefined here it is fixed"),
        //            CostCenterName1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //            CostCenterName2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //            CostCenterName3 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //            DepartmentID = table.Column<int>(type: "int", nullable: false, comment: "HRMSDepartment.DepartmentID where active=Y"),
        //            ProjectID = table.Column<int>(type: "int", nullable: false, comment: "tblProject.ProjectID where active=Y"),
        //            GLControlAccountID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "((0))", comment: "Status of this CC will be reported here in the GL to know actually how this CC"),
        //            SLRevenueAccountID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "((0))", comment: "all the Revenue of this CC will be reported here"),
        //            SLExpenseAccountID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "((0))", comment: "all the expenses of this CC will be reported here"),
        //            SLStockInHandAccountID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "((0))", comment: "all the expenses of this CC will be reported here"),
        //            GroupUnder = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Stock or Investment in the Hand will be reported in this Account here"),
        //            DisplayOrder = table.Column<int>(type: "int", nullable: true),
        //            Active = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: true),
        //            CUSERID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_FACostCenter", x => new { x.TenentID, x.LocationId, x.CostCenterID });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "FAGLAccount",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false),
        //            LocationId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
        //            GLAccountID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValueSql: "((0))"),
        //            Header = table.Column<bool>(type: "bit", nullable: true, comment: "Header Yes than this account can be used than many below will be bypassed"),
        //            MasterAccountID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValueSql: "((0))", comment: "Incase this falls into another Accounts Group than within GL or SL we will choose account"),
        //            ConsolidationType = table.Column<string>(type: "nchar(2)", fixedLength: true, maxLength: 2, nullable: false, defaultValueSql: "((0))", comment: "Consolidation MO=Monthly / WK=Weekly / DA=Daily / YR=Yearly / PR=Once in the Period"),
        //            GLSLType = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false, comment: "GL=General Ledger Always by default GL"),
        //            ActPredGroupId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "FAActPredGroup.ActPredGroupId "),
        //            ActGroupId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "FAAcountGroup.ActGroupID where GLSL=GL"),
        //            InternalGroupId = table.Column<int>(type: "int", nullable: false, comment: "coming from REFID from RefType=ACT RefSubtype=Group"),
        //            GLAccountName1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
        //            GLAccountName2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //            GLAccountName3 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //            ActType = table.Column<int>(type: "int", nullable: false, comment: "REFID From the RefTable REFTYPE=AccountTyp REFSUBTYPE=Type (Assets, Liabilities, Equity, Revenue, Expenses)"),
        //            ActSubType = table.Column<int>(type: "int", nullable: false, comment: "REFID From the RefTable REFTYPE=AccountTyp REFSUBTYPE=SubType based upon above choosen Account Type this sub type will be displayed"),
        //            AnalysisType = table.Column<int>(type: "int", nullable: false, comment: "REFID From the RefTable REFTYPE=AccountTyp REFSUBTYPE=AnalysisType Purchase / Sales / Stock / Cost of the Stock"),
        //            DefaultCC = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //            OPAmount = table.Column<int>(type: "int", nullable: false),
        //            OPDrCr = table.Column<int>(type: "int", nullable: false),
        //            OPPERIOD_CODE = table.Column<long>(type: "bigint", nullable: false, comment: "from TblPeriod where SystemName=Finance/ACT"),
        //            Reference = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Same as used in the tblcontact"),
        //            Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
        //            COMPID = table.Column<int>(type: "int", nullable: false, comment: "if this has relation with tblcompanysetup than take if this has relation with tblcompanysetup.compid default=99999(Not Found in the table)"),
        //            ContactMyID = table.Column<int>(type: "int", nullable: false, comment: "if this has relation with tblcontact than take if this has relation with tblcontact.contactid default=99999(Not Found in the table)"),
        //            SWITCH1 = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
        //            SWITCH2 = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
        //            SWITCH3 = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
        //            ACTIVE = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true, defaultValueSql: "('Y')"),
        //            SyncDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_FAAccountLedger", x => new { x.TenentID, x.LocationId, x.GLAccountID })
        //                .Annotation("SqlServer:Clustered", false);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Families",
        //        schema: "Accounts",
        //        columns: table => new
        //        {
        //            FamilyID = table.Column<int>(type: "int", nullable: false),
        //            FamilyName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
        //            ArabicName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //            OtherName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
        //            crupid = table.Column<long>(type: "bigint", nullable: true),
        //            FamilyCode = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Families", x => x.FamilyID);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "FASLAccount",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false),
        //            LocationId = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
        //            GLAccountID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValueSql: "((0))"),
        //            SLAccountID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValueSql: "((0))"),
        //            Header = table.Column<bool>(type: "bit", nullable: true, comment: "Header Yes than this account can be used than many below will be bypassed"),
        //            MasterAccountID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Incase this falls into another Accounts Group than within SL we will choose account If Header=Yes than this cant be used\r\n"),
        //            PredAccountID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Comming from FAAPredGroup"),
        //            ConsolidationType = table.Column<string>(type: "nchar(2)", fixedLength: true, maxLength: 2, nullable: false, defaultValueSql: "((0))", comment: "Consolidation MO=Monthly / WK=Weekly / DA=Daily / YR=Yearly / PR=Once in the Period"),
        //            GLSLType = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false, comment: "GL=General Ledger Always by default SL"),
        //            ActGroupId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "FAAcountGroup.ActGroupID where GLSL=SL"),
        //            InternalGroupId = table.Column<int>(type: "int", nullable: false, comment: "coming from REFID from RefType=ACT RefSubtype=Group"),
        //            SLAccountName1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
        //            SLAccountName2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //            SLAccountName3 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //            ActType = table.Column<int>(type: "int", nullable: false, comment: "REFID From the RefTable REFTYPE=AccountTyp REFSUBTYPE=Type (Assets, Liabilities, Equity, Revenue, Expenses)"),
        //            ActSubType = table.Column<int>(type: "int", nullable: false, comment: "REFID From the RefTable REFTYPE=AccountTyp REFSUBTYPE=SubType based upon above choosen Account Type this sub type will be displayed"),
        //            AnalysisType = table.Column<int>(type: "int", nullable: false, comment: "REFID From the RefTable REFTYPE=AccountTyp REFSUBTYPE=AnalysisType Purchase / Sales / Stock / Cost of the Stock"),
        //            DefaultCC = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //            OPAmount = table.Column<int>(type: "int", nullable: false),
        //            OPDrCr = table.Column<int>(type: "int", nullable: false),
        //            OPPERIOD_CODE = table.Column<long>(type: "bigint", nullable: false, comment: "from TblPeriod where SystemName=Finance/ACT"),
        //            Reference = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Same as used in the tblcontact"),
        //            Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
        //            COMPID = table.Column<int>(type: "int", nullable: false, comment: "if this has relation with tblcompanysetup than take if this has relation with tblcompanysetup.compid default=99999(Not Found in the table)"),
        //            ContactMyID = table.Column<int>(type: "int", nullable: false, comment: "if this has relation with tblcontact than take if this has relation with tblcontact.contactid default=99999(Not Found in the table)"),
        //            SWITCH1 = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
        //            SWITCH2 = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
        //            SWITCH3 = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
        //            ACTIVE = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true, defaultValueSql: "('Y')"),
        //            SyncDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_FASLAccount", x => new { x.TenentID, x.LocationId, x.GLAccountID, x.SLAccountID })
        //                .Annotation("SqlServer:Clustered", false);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "FinancialPeriod",
        //        schema: "Accounts",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
        //            LocationID = table.Column<int>(type: "int", nullable: false),
        //            FPeriodID = table.Column<int>(type: "int", nullable: false),
        //            YearCode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
        //            DescripitonEng = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            DescripitonArabic = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            StartDate = table.Column<DateTime>(type: "date", nullable: true),
        //            EndDate = table.Column<DateTime>(type: "date", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            crupid = table.Column<long>(type: "bigint", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_FinancialPeriod", x => new { x.TenentID, x.LocationID, x.FPeriodID });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "FormTitleHD",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false),
        //            Language = table.Column<int>(type: "int", nullable: false, comment: "1= English 2=Arabic you can take from reftable refsubtype='Language'"),
        //            FormID = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Make sure you are not using any special character here"),
        //            FormName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            HeaderName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
        //            SubHeader = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            Navigation = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
        //            Remarks = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
        //            Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_FormTitleHD", x => new { x.TenentID, x.FormID, x.Language });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ICCATSUBCAT",
        //        columns: table => new
        //        {
        //            COMPANYID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))", comment: "Company ID"),
        //            MYCATSUBID = table.Column<int>(type: "int", nullable: false),
        //            CATID = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((9999))"),
        //            CATTYPE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, defaultValueSql: "('NONE')"),
        //            SUBCATID = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((9999))"),
        //            SUBCATTYPE = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, defaultValueSql: "('ZZZ')"),
        //            REMARKS = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //            ITEMID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            status = table.Column<int>(type: "int", nullable: true),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ICCATSUBCAT", x => new { x.COMPANYID, x.MYCATSUBID });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "LettersHD",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
        //            MYTRANSID = table.Column<long>(type: "bigint", nullable: false),
        //            LetterType = table.Column<int>(type: "int", nullable: false, comment: "from RefTable RefSubType='LetterType'"),
        //            SenderReceiverParty = table.Column<int>(type: "int", nullable: true, comment: "Where this Letter is Filled at the Folder it is coming from RefTable RefSubType='Party'"),
        //            FilledAt = table.Column<int>(type: "int", nullable: true, comment: "Where this Letter is Filled at the Folder it is coming from RefTable RefSubType='FilingPlace'"),
        //            locationID = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))", comment: "from DMS generated ID to fetch that Letter from there"),
        //            employeeID = table.Column<int>(type: "int", nullable: true, comment: "Received or Sent / Sign by "),
        //            LetterDated = table.Column<DateTime>(type: "date", nullable: true),
        //            Representative = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            Received_SentDate = table.Column<DateTime>(type: "date", nullable: true, comment: "If there is Master Service id than unique of the ServiceSetup.ServiceID except this raw ServiceID will be in the drop Down\r\nIf this service ID Does not have any master or consecutive than it will be same as ServiceID"),
        //            SearchTag = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true, defaultValueSql: "('0')", comment: "SearchTagwill be stored here with Comma Seperated coming from RefTable RefSubType='FilingTag'"),
        //            Description = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "('0')"),
        //            DMSID = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
        //            Status = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: true),
        //            USERID = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
        //            ACTIVE = table.Column<bool>(type: "bit", nullable: true),
        //            ENTRYDATE = table.Column<DateTime>(type: "datetime", nullable: true),
        //            ENTRYTIME = table.Column<DateTime>(type: "datetime", nullable: true),
        //            UPDTTIME = table.Column<DateTime>(type: "datetime", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_LettersHD", x => new { x.TenentID, x.MYTRANSID, x.LetterType })
        //                .Annotation("SqlServer:Clustered", false);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Location",
        //        columns: table => new
        //        {
        //            LocationID = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            TenentID = table.Column<int>(type: "int", nullable: true),
        //            LocationName = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
        //            LocationName_Arabic = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
        //            CreatedDate = table.Column<DateTime>(type: "date", nullable: true),
        //            UserID = table.Column<int>(type: "int", nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Location", x => x.LocationID);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Mapping",
        //        schema: "Accounts",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
        //            locationID = table.Column<int>(type: "int", nullable: false),
        //            MappingID = table.Column<int>(type: "int", nullable: false),
        //            EnglishDescription = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
        //            ArabicDescription = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
        //            OtherDescription = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
        //            Account_ID = table.Column<int>(type: "int", nullable: false),
        //            crupid = table.Column<long>(type: "bigint", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Mapping", x => new { x.TenentID, x.locationID, x.MappingID });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "MappingHeads",
        //        schema: "Accounts",
        //        columns: table => new
        //        {
        //            MappingID = table.Column<int>(type: "int", nullable: true),
        //            Description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "MYCOMPANYSETUP",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
        //            TenantGroupID = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
        //            PHYSICALLOCID = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true, defaultValueSql: "('HLY')"),
        //            COMPNAME1 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
        //            COMPNAME2 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
        //            COMPNAME3 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
        //            COUNTRYID = table.Column<int>(type: "int", nullable: false),
        //            ADDR1 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
        //            ADDR2 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            CITY = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
        //            STATE = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
        //            POSTALCODE = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
        //            ZIPCODE = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
        //            PHONE = table.Column<string>(type: "varchar(24)", unicode: false, maxLength: 24, nullable: false),
        //            FAX = table.Column<string>(type: "varchar(24)", unicode: false, maxLength: 24, nullable: false),
        //            ARABIC = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, defaultValueSql: "('2')"),
        //            DECIMALCURRENCY = table.Column<decimal>(type: "numeric(9,3)", nullable: false, defaultValueSql: "((3))"),
        //            REPORTDEFAULT = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, defaultValueSql: "('0')"),
        //            REPORTDIRECTORY = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            DATADIRECTORY = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            BACKUPDIRECTORY = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            EXECUTABLEDIRECTORY = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            INVDATABASENAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            ACTDATABASENAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            Language1 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
        //            Language2 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
        //            Language3 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
        //            USERID = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
        //            ENTRYDATE = table.Column<DateTime>(type: "datetime", nullable: false),
        //            ENTRYTIME = table.Column<DateTime>(type: "datetime", nullable: false),
        //            UPDTTIME = table.Column<DateTime>(type: "datetime", nullable: false),
        //            REC_RUNNING_SRL = table.Column<int>(type: "int", nullable: true),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: true),
        //            COMPANYID = table.Column<int>(type: "int", nullable: true),
        //            COMPNAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            COMPNAMEO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            COMPNAMECH = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            Approved = table.Column<int>(type: "int", nullable: true),
        //            Companytype = table.Column<int>(type: "int", nullable: true),
        //            StockTaking = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
        //            sysname = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
        //            PeriodID = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
        //            PeriodStartDate = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
        //            PeriodEndDate = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
        //            SalePrice1 = table.Column<decimal>(type: "numeric(3,0)", nullable: true),
        //            SalePrice2 = table.Column<decimal>(type: "numeric(3,0)", nullable: true),
        //            SalePrice3 = table.Column<decimal>(type: "numeric(3,0)", nullable: true),
        //            msrp = table.Column<decimal>(type: "numeric(3,0)", nullable: true),
        //            LogotoDisplay = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            LogotoPrint = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            Logo3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            ACTIVETENENT = table.Column<bool>(type: "bit", nullable: true),
        //            TENENTDATE = table.Column<DateTime>(type: "date", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_MYCOMPANYSETUP", x => x.TenentID)
        //                .Annotation("SqlServer:Clustered", false);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "RefLabelMST",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false),
        //            RefLabelID = table.Column<int>(type: "int", nullable: false),
        //            RefType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
        //            RefSubType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
        //            LE1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LE2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LE3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LE4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LE5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LE6 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LE7 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LE8 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LE9 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LE10 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LF1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LF2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LF3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LF4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LF5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LF6 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LF7 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LF8 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LF9 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LF10 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LA1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LA2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LA3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LA4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LA5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LA6 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LA7 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LA8 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LA9 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LA10 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_RefLabelMST", x => new { x.TenentID, x.RefLabelID, x.RefType, x.RefSubType });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "REFTABLE",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
        //            REFID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
        //            REFTYPE = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false, defaultValueSql: "('OTH')"),
        //            REFSUBTYPE = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, defaultValueSql: "('OTH')"),
        //            SHORTNAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            REFNAME1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            REFNAME2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
        //            REFNAME3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
        //            SWITCH1 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            SWITCH2 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            SWITCH3 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            SWITCH4 = table.Column<int>(type: "int", nullable: true),
        //            Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
        //            ACTIVE = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true, defaultValueSql: "('Y')"),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: true),
        //            Infrastructure = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
        //            REF_Image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
        //            UploadDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            Uploadby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            SyncDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            Syncby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            SynID = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_REFTABLE", x => new { x.TenentID, x.REFID, x.REFTYPE, x.REFSUBTYPE });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "RefTableAdmin",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false),
        //            RefAdminId = table.Column<int>(type: "int", nullable: false),
        //            RefType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
        //            RefSubType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
        //            MySysName = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: false),
        //            Descrip = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
        //            Admin = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
        //            NormalUser = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
        //            switch1 = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: true),
        //            Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
        //            StartSerial = table.Column<int>(type: "int", nullable: true),
        //            EndSerial = table.Column<int>(type: "int", nullable: true),
        //            Active = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: true),
        //            Infrastructure = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
        //            SyncDate = table.Column<DateTime>(type: "datetime", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_RefTableAdmin", x => new { x.TenentID, x.RefAdminId, x.RefType, x.RefSubType });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "ServiceSetup",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false),
        //            ServiceID = table.Column<int>(type: "int", nullable: false),
        //            MasterServiceID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false, comment: "Accept Comma Seperated ID from Drop Down ..\r\nIf there is Master Service id than unique of the ServiceSetup.ServiceID except this raw ServiceID will be in the drop Down\r\nIf this service ID Does not have any master or consecutive than it will be same as ServiceID"),
        //            SerIDByUser = table.Column<int>(type: "int", nullable: false),
        //            ServiceName1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
        //            ServiceName2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
        //            ServiceType = table.Column<int>(type: "int", nullable: true, comment: "Coming from RefTable RefType='KUPF' and RefSubtype='ServiceType'"),
        //            ServiceSubType = table.Column<int>(type: "int", nullable: true, comment: "Coming from RefTable RefType='KUPF' and RefSubtype='ConsumerLoanType' and Switch3=ServiceSetup.ServiceID"),
        //            AllowSponser = table.Column<int>(type: "int", nullable: true, comment: "Allow Sponser for this Services or no"),
        //            AllowedNonEmployes = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true, defaultValueSql: "((1))", comment: "Allowed Non Employee in this Service Y/N"),
        //            MinMonthsService = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((3))"),
        //            MinInstallment = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))", comment: "Incase Min is remain 0 than max must be zero too if Min is other than Zero than Max must be equallant or greater than Zero"),
        //            MaxInstallment = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((8))"),
        //            Frozen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((1))", comment: "Allowed to be Frozen"),
        //            PreviousEmployees = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((1))", comment: "Allowed by Previous Employees"),
        //            SerApproval1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Coming from RefTable RefSubType='Role' and\r\n Which AprovalEmployeeRole will be allowed to be approved else it is to be left NULL"),
        //            SerApproval2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Which AprovalEmployeeRole will be allowed to be approved else it is to be left NULL"),
        //            SerApproval3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Which AprovalEmployeeRole will be allowed to be approved else it is to be left NULL"),
        //            SerApproval4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Which AprovalEmployeeRole will be allowed to be approved else it is to be left NULL"),
        //            SerApproval5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Which AprovalEmployeeRole will be allowed to be approved else it is to be left NULL"),
        //            FinalApproval = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true, comment: "Here you will place which SerApproval# is the last for example 1,2,3,4,5"),
        //            REMARKS = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
        //            Keyword = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
        //            LoanAct = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            HajjAct = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            PersLoanAct = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            ConsumerLoanAct = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account"),
        //            OtherAct1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account"),
        //            OtherAct2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account"),
        //            OtherAct3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account"),
        //            OtherAct4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account"),
        //            SortBy = table.Column<short>(type: "smallint", nullable: true),
        //            Active = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: true),
        //            USERID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            ENTRYDATE = table.Column<DateTime>(type: "datetime", nullable: true),
        //            ENTRYTIME = table.Column<DateTime>(type: "datetime", nullable: true),
        //            UPDTTIME = table.Column<DateTime>(type: "datetime", nullable: true),
        //            UploadDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            Uploadby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            SyncDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            Syncby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            SynID = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Service", x => new { x.TenentID, x.ServiceID });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "SubHead",
        //        schema: "Accounts",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
        //            LocationID = table.Column<int>(type: "int", nullable: false),
        //            SubHeadID = table.Column<int>(type: "int", nullable: false),
        //            Head_ID = table.Column<int>(type: "int", nullable: false),
        //            SubHeadCode = table.Column<int>(type: "int", nullable: false),
        //            SubHeadName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
        //            ArabicSubHeadName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //            Remarks = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
        //            IsActive = table.Column<bool>(type: "bit", nullable: false),
        //            CreatedBy = table.Column<int>(type: "int", nullable: true),
        //            CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            UpdatedBy = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            crupid = table.Column<long>(type: "bigint", nullable: true),
        //            CrFlag = table.Column<int>(type: "int", nullable: true),
        //            BalanceAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValueSql: "((0))")
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_SubHead", x => new { x.TenentID, x.LocationID, x.SubHeadID });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "SubSubHead",
        //        schema: "Accounts",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false),
        //            LocationID = table.Column<int>(type: "int", nullable: false),
        //            SubSubHeadID = table.Column<int>(type: "int", nullable: false),
        //            SubHead_ID = table.Column<int>(type: "int", nullable: true),
        //            Head_ID = table.Column<int>(type: "int", nullable: true),
        //            SubSubHeadCode = table.Column<int>(type: "int", nullable: true),
        //            SubSubHeadName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
        //            ArabicSubSubHeadName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: true),
        //            CreatedBy = table.Column<int>(type: "int", nullable: true),
        //            CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            UpdatedBy = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            crupid = table.Column<int>(type: "int", nullable: true),
        //            BalanceAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValueSql: "((0))")
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK__SubSubHe__5298A9220DD76A00", x => new { x.TenentID, x.LocationID, x.SubSubHeadID });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "tbl_Account_Mst",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false),
        //            ID = table.Column<int>(type: "int", nullable: false),
        //            Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            Phone_Office = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            Phone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            Phone_Fax = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            Phone_Alternate = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            Website = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            Email1 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            Email2 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            Annual_Revenue = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            Employee = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            IndustryID = table.Column<int>(type: "int", nullable: true),
        //            Ownership = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
        //            AccountType = table.Column<int>(type: "int", nullable: true),
        //            TickerSymbol = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            Rating = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
        //            SicCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            Billing_Address_Street = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
        //            Billing_Address_City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            Billing_Address_State = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            Billing_Address_Postalcode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            Billing_Address_Country = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            Shipping_Address_Street = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
        //            Shipping_Address_City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            Shipping_Address_State = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            Shipping_Address_Postalcode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            Shipping_Address_Country = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            ParentName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            DateEntered = table.Column<DateTime>(type: "datetime", nullable: true),
        //            DateModified = table.Column<DateTime>(type: "datetime", nullable: true),
        //            Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
        //            TeamName = table.Column<int>(type: "int", nullable: true),
        //            Assigned_to_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            CreatedBy = table.Column<int>(type: "int", nullable: true),
        //            ModifiedBy = table.Column<int>(type: "int", nullable: true),
        //            ContactName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            Active = table.Column<bool>(type: "bit", nullable: true),
        //            Deleted = table.Column<bool>(type: "bit", nullable: true),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_CRM_tbl_Account_Mst", x => new { x.TenentID, x.ID });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "tblActSLSetup",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false),
        //            locationID = table.Column<int>(type: "int", nullable: false),
        //            transid = table.Column<int>(type: "int", nullable: false),
        //            transsubid = table.Column<int>(type: "int", nullable: false),
        //            module = table.Column<int>(type: "int", nullable: true),
        //            DeliveryLocation = table.Column<int>(type: "int", nullable: true),
        //            CompniID = table.Column<int>(type: "int", nullable: true),
        //            LastClosePeriod = table.Column<int>(type: "int", nullable: true),
        //            CurrentPeriod = table.Column<int>(type: "int", nullable: true),
        //            PaymentDays = table.Column<int>(type: "int", nullable: true),
        //            ReminderDays = table.Column<int>(type: "int", nullable: true),
        //            AcceptWarantee = table.Column<int>(type: "int", nullable: true),
        //            DescWithWarantee = table.Column<bool>(type: "bit", nullable: true),
        //            DescWithSerial = table.Column<bool>(type: "bit", nullable: true),
        //            DescWithColor = table.Column<bool>(type: "bit", nullable: true),
        //            AllowMinusQty = table.Column<bool>(type: "bit", nullable: true),
        //            HeaderLine = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
        //            TagLine = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
        //            BottomTagLine = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            PaymentDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            TCQuotation = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            IntroLetter = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            COUNTRYID = table.Column<int>(type: "int", nullable: true),
        //            SalesAdminID = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_tblActSLSetup", x => new { x.TenentID, x.locationID, x.transid, x.transsubid });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "tblAudit",
        //        columns: table => new
        //        {
        //            TENANT_ID = table.Column<long>(type: "bigint", nullable: false),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: false),
        //            MySerial = table.Column<int>(type: "int", nullable: false),
        //            AuditNo = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            AuditType = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
        //            TableName = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
        //            FieldName = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
        //            OldValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            NewValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            UpdateUserName = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true),
        //            CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            CreatedUserName = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Audit", x => new { x.TENANT_ID, x.CRUP_ID, x.MySerial, x.AuditNo });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "tblCityStatesCounty",
        //        columns: table => new
        //        {
        //            TenantID = table.Column<int>(type: "int", nullable: false),
        //            CityID = table.Column<int>(type: "int", nullable: false),
        //            StateID = table.Column<int>(type: "int", nullable: false),
        //            COUNTRYID = table.Column<int>(type: "int", nullable: false),
        //            DistrictID = table.Column<int>(type: "int", nullable: true),
        //            DistrictName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
        //            CityEnglish = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, defaultValueSql: "((1))"),
        //            CityArabic = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
        //            CityOther = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
        //            LandLine = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //            ACTIVE1 = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
        //            ACTIVE2 = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: true),
        //            AssignedRoute = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            SHORTCODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            ZONE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            UploadDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            Uploadby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            SyncDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            Syncby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            SynID = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_tblCityStatesCounty1", x => new { x.TenantID, x.CityID, x.StateID, x.COUNTRYID });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "TBLCOMPANYSETUP",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false),
        //            COMPID = table.Column<int>(type: "int", nullable: false),
        //            MYCONLOCID = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
        //            OldCOMPid = table.Column<int>(type: "int", nullable: true),
        //            PHYSICALLOCID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
        //            COMPNAME1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            COMPNAME2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            COMPNAME3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            BirthDate = table.Column<DateTime>(type: "date", nullable: true),
        //            CivilID = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true),
        //            EMAIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            EMAIL1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            EMAIL2 = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: true),
        //            ITMANAGER = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Employee ID incase he is an Employee of the Company incase this field is Null than will considered to be a temporary Driver"),
        //            ADDR1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ADDR2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            DistrictID = table.Column<int>(type: "int", nullable: true),
        //            CITY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((1))"),
        //            STATE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((0))"),
        //            POSTALCODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((0))"),
        //            ZIPCODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((0))"),
        //            MYPRODID = table.Column<long>(type: "bigint", nullable: true),
        //            COUNTRYID = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((126))"),
        //            BUSPHONE1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((0))"),
        //            BUSPHONE2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((0))"),
        //            BUSPHONE3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((0))"),
        //            BUSPHONE4 = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true, defaultValueSql: "((0))"),
        //            MOBPHONE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((0))"),
        //            ALTMOBPHONE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((0))"),
        //            FAX = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((0))"),
        //            FAX1 = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true, defaultValueSql: "((0))"),
        //            FAX2 = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true, defaultValueSql: "((0))"),
        //            PRIMLANGUGE = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true, defaultValueSql: "('E')"),
        //            WEBPAGE = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true, defaultValueSql: "((0))"),
        //            ISMINISTRY = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
        //            ISSMB = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
        //            ISCORPORATE = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
        //            INHAWALLY = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
        //            SALER = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
        //            BUYER = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
        //            SALEDEPROD = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
        //            EMAISUB = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
        //            EMAILSUBDATE = table.Column<DateTime>(type: "datetime", nullable: true),
        //            PRODUCTDEALIN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "((0))"),
        //            REMARKS = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "((0))"),
        //            Keyword = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "((0))"),
        //            COMPANYID = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
        //            BUSID = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
        //            ReferenceNumber = table.Column<int>(type: "int", nullable: true),
        //            ProfitPercDuringSale = table.Column<decimal>(type: "decimal(8,2)", nullable: true, comment: "During Sales the percentage it is 8,2 like 99.99 only"),
        //            Nationality = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            Country = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            Status = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
        //            DefaultAddress = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            MYCATSUBID = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
        //            COMPNAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((0))"),
        //            COMPNAMEO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((0))"),
        //            COMPNAMECH = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "((0))"),
        //            Active = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true, defaultValueSql: "((1))"),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: true, defaultValueSql: "((0))"),
        //            CUSERID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((0))"),
        //            CPASSWRD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((0))"),
        //            USERID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((0))"),
        //            ENTRYDATE = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "((0))"),
        //            ENTRYTIME = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "((0))"),
        //            UPDTTIME = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "((0))"),
        //            Approved = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
        //            CompanyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((0))"),
        //            CompanyType_Ref = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
        //            Images = table.Column<byte[]>(type: "image", nullable: true),
        //            BARCODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((0))"),
        //            Avtar = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "((0))"),
        //            Reload = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
        //            datasource = table.Column<int>(type: "int", nullable: true),
        //            PACI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            Marketting = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
        //            UploadDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            Uploadby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            SyncDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            Syncby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            SynID = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_TBLCOMPANYSETUP", x => new { x.TenentID, x.COMPID });
        //        },
        //        comment: "Company Data");

        //    migrationBuilder.CreateTable(
        //        name: "TBLCONTACT_DEL_ADRES",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false),
        //            ContactMyID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
        //            DeliveryAdressID = table.Column<int>(type: "int", nullable: false, comment: "select * from reftable where tenentID=18 and reftype = 'COURIER' and REFSUBTYPE= 'AdresLocation' order by 5 "),
        //            CompID = table.Column<int>(type: "int", nullable: true),
        //            CompLoc = table.Column<int>(type: "int", nullable: true),
        //            GoogleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Latitute = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            Longitute = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            ContactID = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
        //            AdressShortName1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            AdressName1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            ADDR1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ADDR2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ADDR3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            PACINumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //            DistrictID = table.Column<int>(type: "int", nullable: true),
        //            CITY = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValueSql: "((1))"),
        //            STATE = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //            COUNTRYID = table.Column<int>(type: "int", nullable: true),
        //            Block = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            Building = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
        //            Street = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
        //            Lane = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
        //            FloorNo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            ForFlat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            REMARKS = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: true),
        //            CUSERID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            ENTRYDATE = table.Column<DateTime>(type: "datetime", nullable: true),
        //            ENTRYTIME = table.Column<DateTime>(type: "datetime", nullable: true),
        //            UPDTTIME = table.Column<DateTime>(type: "datetime", nullable: true),
        //            Active = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
        //            Defualt = table.Column<bool>(type: "bit", nullable: true),
        //            UploadDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            Uploadby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            SyncDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            Syncby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            SynID = table.Column<int>(type: "int", nullable: true),
        //            syncStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            PostCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            Address3 = table.Column<string>(type: "nchar(250)", fixedLength: true, maxLength: 250, nullable: true),
        //            UpdatedBy = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
        //            CreatedBy = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_TBLCONTACT_DEL_ADRES", x => new { x.TenentID, x.ContactMyID, x.DeliveryAdressID });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "tblCOUNTRY",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false),
        //            COUNTRYID = table.Column<int>(type: "int", nullable: false),
        //            REGION1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            COUNAME1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
        //            COUNAME2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            COUNAME3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            CAPITAL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
        //            NATIONALITY1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
        //            NATIONALITY2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            NATIONALITY3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            CURRENCYNAME1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
        //            CURRENCYNAME2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            CURRENCYNAME3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            CURRENTCONVRATE = table.Column<decimal>(type: "numeric(8,5)", nullable: false, defaultValueSql: "((1))"),
        //            CURRENCYSHORTNAME1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            CURRENCYSHORTNAME2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            CURRENCYSHORTNAME3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            CountryType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
        //            CountryTSubType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            Sovereignty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            ISO4217CurCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
        //            ISO4217CurName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            ITUTTelephoneCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
        //            FaxLength = table.Column<int>(type: "int", nullable: true),
        //            TelLength = table.Column<int>(type: "int", nullable: true),
        //            ISO3166_1_2LetterCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            ISO3166_1_3LetterCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
        //            ISO3166_1Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            IANACountryCodeTLD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            zone1 = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: true),
        //            zone2 = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: true),
        //            zone3 = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: true),
        //            zone4 = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: true),
        //            zone5 = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: true),
        //            zone6 = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: true),
        //            zone7 = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: true),
        //            Active = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: true),
        //            UploadDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            Uploadby = table.Column<string>(type: "text", nullable: true),
        //            SyncDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            Syncby = table.Column<string>(type: "text", nullable: true),
        //            SynID = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_tblCOUNTRY_1", x => new { x.TenentID, x.COUNTRYID });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "tblDistrictStatesCounty",
        //        columns: table => new
        //        {
        //            TenantID = table.Column<int>(type: "int", nullable: false),
        //            COUNTRYID = table.Column<int>(type: "int", nullable: false),
        //            StateID = table.Column<int>(type: "int", nullable: false),
        //            DistrictID = table.Column<int>(type: "int", nullable: false),
        //            PinCode = table.Column<int>(type: "int", nullable: true),
        //            DistrictEnglish = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
        //            DistrictArabic = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
        //            DistrictOther = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
        //            LandLine = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //            ACTIVE1 = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
        //            ACTIVE2 = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: true),
        //            AssignedRoute = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            SHORTCODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            ZONE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            UploadDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            Uploadby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            SyncDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            Syncby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            SynID = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_tblDistrictStatesCounty", x => new { x.TenantID, x.COUNTRYID, x.StateID, x.DistrictID });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "tblImportCOA",
        //        columns: table => new
        //        {
        //            FamilyName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            HeadName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
        //            ArabicHeadName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
        //            HeadCode = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
        //            SubHeadName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
        //            ArabicSubHeadName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
        //            SubHeadCode = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
        //            AccountName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
        //            ArabicAccountName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
        //            AccountNumber = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
        //            BankAccountNo = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
        //            AccountTypeName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
        //            TanentID = table.Column<int>(type: "int", nullable: true),
        //            LocationID = table.Column<int>(type: "int", nullable: true),
        //            UserID = table.Column<int>(type: "int", nullable: true),
        //            ActivityDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
        //            SubSubHeadCode = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
        //            SubSubHeadName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
        //            SubSubHeadNameArabic = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
        //            Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
        //            FamilyCode = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "tblImportCOAV2",
        //        columns: table => new
        //        {
        //            FamilyName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            HeadName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
        //            ArabicHeadName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
        //            HeadCode = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
        //            SubHeadName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
        //            ArabicSubHeadName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
        //            SubHeadCode = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
        //            AccountName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
        //            ArabicAccountName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
        //            AccountNumber = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
        //            BankAccountNo = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
        //            AccountTypeName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
        //            TanentID = table.Column<int>(type: "int", nullable: true),
        //            LocationID = table.Column<int>(type: "int", nullable: true),
        //            UserID = table.Column<int>(type: "int", nullable: true),
        //            ActivityDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
        //            SubSubHeadCode = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
        //            SubSubHeadName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
        //            SubSubHeadNameArabic = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
        //            Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
        //            FamilyCode = table.Column<int>(type: "int", nullable: true),
        //            AccountID = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1")
        //        },
        //        constraints: table =>
        //        {
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "tblImportVoucher",
        //        columns: table => new
        //        {
        //            TanentID = table.Column<int>(type: "int", nullable: true),
        //            LocationID = table.Column<int>(type: "int", nullable: true),
        //            VoucherType_ID = table.Column<int>(type: "int", nullable: true),
        //            SerialNo = table.Column<int>(type: "int", nullable: true),
        //            VoucherDate = table.Column<DateTime>(type: "date", nullable: true),
        //            AccountName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
        //            Remarks = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
        //            ChequeNo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            ChequeDate = table.Column<DateTime>(type: "date", nullable: true),
        //            Debit = table.Column<double>(type: "float", nullable: true),
        //            Credit = table.Column<double>(type: "float", nullable: true),
        //            UserID = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "TBLPERIODS",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
        //            PERIOD_CODE = table.Column<long>(type: "bigint", nullable: false),
        //            MYSYSNAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
        //            PRD_YEAR = table.Column<short>(type: "smallint", nullable: false),
        //            PRD_MONTH = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
        //            PRD_PERIOD1 = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
        //            PRD_PERIOD2 = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
        //            PRD_PERIOD3 = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
        //            PRD_START_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
        //            PRD_END_DATE = table.Column<DateTime>(type: "datetime", nullable: false),
        //            GLPOST = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true, defaultValueSql: "('2')"),
        //            GLPOSTREF = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
        //            ICPOST = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true, defaultValueSql: "('2')"),
        //            ICPOSTREF = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
        //            STATUS1 = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true, defaultValueSql: "('2')"),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: true),
        //            PRD_PERIOD = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_TBLPERIODS", x => new { x.TenentID, x.PERIOD_CODE, x.MYSYSNAME })
        //                .Annotation("SqlServer:Clustered", false);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "tblStates",
        //        columns: table => new
        //        {
        //            COUNTRYID = table.Column<int>(type: "int", nullable: false),
        //            StateID = table.Column<int>(type: "int", nullable: false),
        //            MYNAME1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
        //            MYNAME2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            MYNAME3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            STATEZIPCODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            ACTIVE1 = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
        //            ACTIVE2 = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: true),
        //            UploadDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            Uploadby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            SyncDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            Syncby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            SynID = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_tblStates", x => new { x.COUNTRYID, x.StateID });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "tbltranssubtype",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
        //            transid = table.Column<int>(type: "int", nullable: false),
        //            MYSYSNAME = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: false),
        //            transsubid = table.Column<int>(type: "int", nullable: false),
        //            transsubtype1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            transsubtype2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            transsubtype3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            OpQtyBeh = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, defaultValueSql: "('0')"),
        //            OnHandBeh = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, defaultValueSql: "('0')"),
        //            QtyOutBeh = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, defaultValueSql: "('0')"),
        //            QtyConsumedBeh = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, defaultValueSql: "('0')"),
        //            QtyReservedBeh = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, defaultValueSql: "('0')"),
        //            QtyAtDestination = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false, defaultValueSql: "('1')"),
        //            QtyAtSource = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true, defaultValueSql: "('1')"),
        //            serialno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            years = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
        //            Active = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, defaultValueSql: "('1')"),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: true),
        //            transsubtype = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            CashBeh = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
        //            QtyReceivedBeh = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_TBLTRANSSUBTYPE", x => new { x.TenentID, x.transsubid, x.transid, x.MYSYSNAME });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "tbltranstype",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
        //            transid = table.Column<int>(type: "int", nullable: false),
        //            MYSYSNAME = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: false, defaultValueSql: "('IC')"),
        //            inoutSwitch = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true, defaultValueSql: "('I')", comment: "I=In O=Out C=Consume (case Sensitive)"),
        //            transtype1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            transtype2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            transtype3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            serialno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, defaultValueSql: "((1001))", comment: "The Serial number running for this type of the Transaction is stored here in the terms of the main transaction type. This number can be reset by every year as year is mentioned below so when-ever u make transaction id printed use year as preprinted two digita"),
        //            years = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true, defaultValueSql: "((2014))", comment: "Year of the transaction"),
        //            Active = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, defaultValueSql: "('1')"),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: true),
        //            transtype = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            switch1 = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_TBLTRANSTYPE", x => new { x.TenentID, x.transid, x.MYSYSNAME });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "TestCompanies",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_TestCompanies", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "TestTable",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            StudentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_TestTable", x => x.Id);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "TransactionDT",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
        //            locationID = table.Column<int>(type: "int", nullable: false),
        //            MYTRANSID = table.Column<long>(type: "bigint", nullable: false),
        //            MYID = table.Column<int>(type: "int", nullable: false),
        //            employeeID = table.Column<int>(type: "int", nullable: true),
        //            InstallmentNumber = table.Column<decimal>(type: "decimal(18,3)", nullable: true, defaultValueSql: "((0))"),
        //            AttachID = table.Column<int>(type: "int", nullable: true, comment: "TransactionHDDMS.AttachID"),
        //            PERIOD_CODE = table.Column<long>(type: "bigint", nullable: true, comment: "TransactionHDDMS.AttachID"),
        //            InstallmentAmount = table.Column<decimal>(type: "decimal(18,3)", nullable: true, defaultValueSql: "((0))"),
        //            ReceivedAmount = table.Column<decimal>(type: "decimal(18,3)", nullable: true, defaultValueSql: "((0))"),
        //            PendingAmount = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
        //            DiscountAmount = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
        //            DiscountReference = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            UniversityBatchNo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
        //            ReceivedDate = table.Column<DateTime>(type: "date", nullable: true),
        //            EffectedAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account"),
        //            OtherReference = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
        //            ACTIVITYID = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: true),
        //            GLPOST = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, defaultValueSql: "('2')"),
        //            GLPOST1 = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, defaultValueSql: "('2')"),
        //            GLPOSTREF1 = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, defaultValueSql: "('0')"),
        //            GLPOSTREF = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
        //            ACTIVE = table.Column<bool>(type: "bit", nullable: true),
        //            SWITCH1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //            DelFlag = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ICTR_DT", x => new { x.TenentID, x.MYTRANSID, x.locationID, x.MYID })
        //                .Annotation("SqlServer:Clustered", false);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "TransactionHD",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
        //            MYTRANSID = table.Column<long>(type: "bigint", nullable: false),
        //            locationID = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
        //            employeeID = table.Column<int>(type: "int", nullable: true),
        //            ServiceID = table.Column<int>(type: "int", nullable: true),
        //            MasterServiceID = table.Column<int>(type: "int", nullable: true, comment: "If there is Master Service id than unique of the ServiceSetup.ServiceID except this raw ServiceID will be in the drop Down\r\nIf this service ID Does not have any master or consecutive than it will be same as ServiceID"),
        //            ServiceType = table.Column<decimal>(type: "numeric(18,0)", nullable: true, comment: "Coming from RefTable RefType='KUPF' and RefSubtype='ServiceType'"),
        //            ServiceSubType = table.Column<decimal>(type: "numeric(18,0)", nullable: true, comment: "Coming from RefTable RefType='KUPF' and RefSubtype='ConsumerLoanType' and Switch3=ServiceSetup.ServiceID"),
        //            Source = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true, comment: "Online / Local"),
        //            AttachID = table.Column<int>(type: "int", nullable: true),
        //            TransDocNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "TransactionHDDMS.AttachID"),
        //            BankID = table.Column<long>(type: "bigint", nullable: true),
        //            ChequeNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //            ChequeDate = table.Column<DateTime>(type: "date", nullable: true),
        //            ChequeAmount = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
        //            TOTInstallments = table.Column<decimal>(type: "decimal(4,0)", nullable: true, defaultValueSql: "((0))"),
        //            TOTAMT = table.Column<decimal>(type: "decimal(18,3)", nullable: true, defaultValueSql: "((0))"),
        //            AmtPaid = table.Column<decimal>(type: "decimal(18,3)", nullable: true, defaultValueSql: "((0))"),
        //            LoanAct = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            HajjAct = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            PersLoanAct = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            ConsumerLoanAct = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account"),
        //            OtherAct1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account"),
        //            OtherAct2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account"),
        //            OtherAct3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account"),
        //            OtherAct4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "contributions account - \r\nloan account - \r\ntrust account - \r\nsocial assistance account - \r\nfinancial aid account"),
        //            ACTIVITYCODE = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
        //            MYDOCNO = table.Column<decimal>(type: "numeric(20,0)", nullable: true, defaultValueSql: "((0))"),
        //            USERBATCHNO = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
        //            PROJECTNO = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, defaultValueSql: "('0')"),
        //            TRANSDATE = table.Column<DateTime>(type: "datetime", nullable: false),
        //            REFERENCE = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true, defaultValueSql: "('0')"),
        //            NOTES = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValueSql: "('0')"),
        //            GLPOSTREF = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, defaultValueSql: "('0')"),
        //            GLPOSTREF1 = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true, defaultValueSql: "('0')"),
        //            COMPANYID = table.Column<int>(type: "int", nullable: true),
        //            Discount = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
        //            Terms = table.Column<int>(type: "int", nullable: true),
        //            RefTransID = table.Column<int>(type: "int", nullable: true),
        //            signatures = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            ExtraSwitch1 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
        //            ExtraSwitch2 = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
        //            Status = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: true),
        //            USERID = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
        //            ACTIVE = table.Column<bool>(type: "bit", nullable: true),
        //            ENTRYDATE = table.Column<DateTime>(type: "datetime", nullable: true),
        //            ENTRYTIME = table.Column<DateTime>(type: "datetime", nullable: true),
        //            UPDTTIME = table.Column<DateTime>(type: "datetime", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_TransactionHD", x => new { x.TenentID, x.MYTRANSID })
        //                .Annotation("SqlServer:Clustered", false);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "TransactionHDDApprovalDetails  ",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
        //            MYTRANSID = table.Column<long>(type: "bigint", nullable: false),
        //            locationID = table.Column<int>(type: "int", nullable: false),
        //            SerApprovalID = table.Column<decimal>(type: "numeric(18,0)", nullable: false, comment: "REFID Coming from RefTable RefSubType='Role' and\r\n Which AprovalEmployeeRole will be allowed to be approved else it is to be left NULL"),
        //            SerApproval = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "RefName1 having Role Coming from RefTable RefSubType='Role' and\r\n Which AprovalEmployeeRole will be allowed to be approved else it is to be left NULL"),
        //            employeeID = table.Column<int>(type: "int", nullable: true, comment: "Person who approved this his Id"),
        //            ServiceID = table.Column<int>(type: "int", nullable: true),
        //            MasterServiceID = table.Column<int>(type: "int", nullable: true, comment: "If there is Master Service id than unique of the ServiceSetup.ServiceID except this raw ServiceID will be in the drop Down\r\nIf this service ID Does not have any master or consecutive than it will be same as ServiceID"),
        //            ApprovalDate = table.Column<DateTime>(type: "date", nullable: true),
        //            RejectionType = table.Column<decimal>(type: "numeric(18,0)", nullable: true, comment: "Coming from RefTable RefType='KUPF' and  RefSubtype='LoanRefusedType'"),
        //            RejectionRemarks = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
        //            AttachID = table.Column<int>(type: "int", nullable: true),
        //            Status = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: true),
        //            USERID = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
        //            ACTIVE = table.Column<bool>(type: "bit", nullable: true),
        //            ENTRYDATE = table.Column<DateTime>(type: "datetime", nullable: true),
        //            ENTRYTIME = table.Column<DateTime>(type: "datetime", nullable: true),
        //            UPDTTIME = table.Column<DateTime>(type: "datetime", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_TransactionHDDApprovalDetails  _1", x => new { x.TenentID, x.MYTRANSID, x.locationID, x.SerApprovalID });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "TransactionHDDMS ",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false),
        //            MYTRANSID = table.Column<long>(type: "bigint", nullable: false),
        //            AttachID = table.Column<int>(type: "int", nullable: false, comment: "Continues Serial Number for This TenentID and this TransactionID"),
        //            Serialno = table.Column<int>(type: "int", nullable: false, comment: "1,2,3,4 Continues Serial Number for This TenentID, this TransactionID and This AttachmentID "),
        //            DocumentType = table.Column<decimal>(type: "numeric(18,0)", nullable: true, comment: "from  Reftable where refsubtype=â€™ DocTypeâ€™"),
        //            AttachmentPath = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
        //            AttachmentByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            AttachmentsDetail = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
        //            Actived = table.Column<bool>(type: "bit", nullable: true),
        //            Deleted = table.Column<bool>(type: "bit", nullable: true),
        //            CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            CreatedBy = table.Column<int>(type: "int", nullable: true),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: true),
        //            ShareID = table.Column<int>(type: "int", nullable: true),
        //            CATID = table.Column<int>(type: "int", nullable: true),
        //            Subject = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            Keywords = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            MetaTags = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            Action = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            RoutID = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_TransactionHDDMS ", x => new { x.TenentID, x.MYTRANSID, x.AttachID, x.Serialno });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "TreeFunction",
        //        columns: table => new
        //        {
        //            RoleID = table.Column<int>(type: "int", nullable: false),
        //            NodeID = table.Column<int>(type: "int", nullable: false),
        //            TenentID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((21))"),
        //            NodeImageUrl = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
        //            NodeNavUrl = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
        //            IsParent = table.Column<byte>(type: "tinyint", nullable: false),
        //            ParentID = table.Column<int>(type: "int", nullable: false),
        //            ReadAllow = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false, defaultValueSql: "('Y')"),
        //            WriteAllow = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false, defaultValueSql: "('Y')"),
        //            PrintAllow = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false, defaultValueSql: "('Y')"),
        //            DeleteAllow = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false, defaultValueSql: "('N')"),
        //            Other1Allow = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false, defaultValueSql: "('N')"),
        //            Other2Allow = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false, defaultValueSql: "('N')"),
        //            Other3Allow = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false, defaultValueSql: "('N')"),
        //            Other4Allow = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false, defaultValueSql: "('N')"),
        //            Other5Allow = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false, defaultValueSql: "('N')"),
        //            PagePath = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
        //            PageTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
        //            PageTitle1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
        //            PageTitle2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
        //            DashBoardImage = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            MenuOrder = table.Column<int>(type: "int", nullable: true),
        //            IsGraph = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
        //            MenuType = table.Column<byte>(type: "tinyint", nullable: true),
        //            IsVisibleInMenu = table.Column<bool>(type: "bit", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_TreeFunction", x => new { x.RoleID, x.NodeID, x.TenentID });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "TreeNode",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false),
        //            NodeID = table.Column<int>(type: "int", nullable: false),
        //            LocationID = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))", comment: "Branch / Location / Supplier / Customer"),
        //            NodeValue = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
        //            NodeImageUrl = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
        //            NodeNavUrl = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
        //            IsParent = table.Column<byte>(type: "tinyint", nullable: false),
        //            ParentID = table.Column<int>(type: "int", nullable: false),
        //            IsSubParent = table.Column<byte>(type: "tinyint", nullable: true, defaultValueSql: "((0))"),
        //            SubParentID = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
        //            ReadAllow = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: true, defaultValueSql: "(N'Y')"),
        //            WriteAllow = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: true, defaultValueSql: "(N'Y')"),
        //            PrintAllow = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: true, defaultValueSql: "(N'Y')"),
        //            DeleteAllow = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: true, defaultValueSql: "(N'N')"),
        //            Other1 = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: true, defaultValueSql: "(N'N')"),
        //            Other2 = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: true, defaultValueSql: "(N'N')"),
        //            Other3 = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: true, defaultValueSql: "(N'N')"),
        //            Other4 = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: true, defaultValueSql: "(N'N')"),
        //            Other5 = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: true, defaultValueSql: "(N'N')"),
        //            PagePath = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
        //            PageTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
        //            PageTitle1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
        //            PageTitle2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
        //            DashBoardImage = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            MenuOrder = table.Column<int>(type: "int", nullable: true),
        //            SortBy = table.Column<int>(type: "int", nullable: true),
        //            IsGraph = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
        //            MenuType = table.Column<byte>(type: "tinyint", nullable: true),
        //            IsVisibleInMenu = table.Column<bool>(type: "bit", nullable: true),
        //            CommandName = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
        //            Position = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_TreeNode", x => new { x.TenentID, x.NodeID });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "University",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((21))"),
        //            MYCONLOCID = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
        //            UnivIDByUser = table.Column<int>(type: "int", nullable: false),
        //            PHYSICALLOCID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
        //            UnivName1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            UnivName2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            UnivName3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            BeginDate = table.Column<DateTime>(type: "date", nullable: true),
        //            PACIID = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true),
        //            CivilID = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: true),
        //            EMAIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            EMAIL1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            EMAIL2 = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: true),
        //            ADDR1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            ADDR2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
        //            CITY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((1))"),
        //            STATE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((0))"),
        //            COUNTRYID = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((126))"),
        //            BUSPHONE1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((0))"),
        //            MOBPHONE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((0))"),
        //            ALTMOBPHONE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((0))"),
        //            FAX = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((0))"),
        //            FAX1 = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true, defaultValueSql: "((0))"),
        //            FAX2 = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true, defaultValueSql: "((0))"),
        //            PRIMLANGUGE = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true, defaultValueSql: "('E')"),
        //            WEBPAGE = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true, defaultValueSql: "((0))"),
        //            REMARKS = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "((0))"),
        //            Keyword = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, defaultValueSql: "((0))"),
        //            LoanAct = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            ServiceTypeRegular = table.Column<int>(type: "int", nullable: true, comment: "From RefTable REFSubtype='ServiceType'"),
        //            ServiceTypeInfrastructure = table.Column<int>(type: "int", nullable: true, comment: "From RefTable REFSubtype='ServiceType'"),
        //            ServiceTypeCustom = table.Column<int>(type: "int", nullable: true, comment: "From RefTable REFSubtype='ServiceType'"),
        //            ServiceTypeTermination = table.Column<int>(type: "int", nullable: true, comment: "From RefTable REFSubtype='ServiceType'"),
        //            ServiceTypeReimbursement = table.Column<int>(type: "int", nullable: true, comment: "From RefTable REFSubtype='ServiceType'"),
        //            HajjAct = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            PersLoanAct = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            OtherAct1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            OtherAct2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            OtherAct3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            OtherAct4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            OtherAct5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            SerApproval1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Coming from RefTable RefSubType='Role' and\r\n Which AprovalEmployeeRole will be allowed to be approved else it is to be left NULL"),
        //            SerApproval2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Which AprovalEmployeeRole will be allowed to be approved else it is to be left NULL"),
        //            SerApproval3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Which AprovalEmployeeRole will be allowed to be approved else it is to be left NULL"),
        //            SerApproval4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Which AprovalEmployeeRole will be allowed to be approved else it is to be left NULL"),
        //            SerApproval5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Which AprovalEmployeeRole will be allowed to be approved else it is to be left NULL"),
        //            Active = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true, defaultValueSql: "((1))"),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: true, defaultValueSql: "((0))"),
        //            USERID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "((0))"),
        //            ENTRYDATE = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "((0))"),
        //            ENTRYTIME = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "((0))"),
        //            UPDTTIME = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "((0))"),
        //            UploadDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            Uploadby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            SyncDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            Syncby = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            SynID = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_University_1", x => x.TenentID);
        //        },
        //        comment: "Company Data");

        //    migrationBuilder.CreateTable(
        //        name: "USER_DTL",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false),
        //            USER_DETAIL_ID = table.Column<int>(type: "int", nullable: false),
        //            LOCATION_ID = table.Column<int>(type: "int", nullable: false),
        //            CRUP_ID = table.Column<long>(type: "bigint", nullable: false),
        //            COUNTRY_CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            TITLE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            HOUSE_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            STREET = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            ADDRESS1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            ADDRESS2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            CITY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            COUNTRY = table.Column<int>(type: "int", nullable: true),
        //            STATE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            ZIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            PH_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            FAX_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            FROM_REG_DT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            VILLAGE_TOWN_CITY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            TEHSIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            PINCODE_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            POST_OFFICE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            PAN_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            EMAIL_ADDRESS = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
        //            MOBILE_NUM = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
        //            SEC_QUES = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
        //            SEC_ANS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ACM_USER_DTL_1", x => new { x.TenentID, x.USER_DETAIL_ID, x.LOCATION_ID });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "USER_MST",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false),
        //            USER_ID = table.Column<int>(type: "int", nullable: false),
        //            LOCATION_ID = table.Column<int>(type: "int", nullable: false),
        //            CRUP_ID = table.Column<int>(type: "int", nullable: false),
        //            FIRST_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
        //            LAST_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            FIRST_NAME1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LAST_NAME1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            FIRST_NAME2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LAST_NAME2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            LOGIN_ID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
        //            PASSWORD = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
        //            USER_TYPE = table.Column<int>(type: "int", nullable: true),
        //            REMARKS = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
        //            ACTIVE_FLAG = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
        //            LAST_LOGIN_DT = table.Column<DateTime>(type: "datetime", nullable: true),
        //            USER_DETAIL_ID = table.Column<int>(type: "int", nullable: true),
        //            ACC_LOCK = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
        //            FIRST_TIME = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
        //            PASSWORD_CHNG = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
        //            THEME_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            APPROVAL_DT = table.Column<DateTime>(type: "datetime", nullable: true),
        //            VERIFICATION_CD = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
        //            EmailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            Till_DT = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Ayo Till date"),
        //            IsSignature = table.Column<bool>(type: "bit", nullable: true),
        //            SignatureImage = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
        //            Avtar = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
        //            CompId = table.Column<int>(type: "int", nullable: true),
        //            EmpID = table.Column<int>(type: "int", nullable: true),
        //            CheckinSwitch = table.Column<bool>(type: "bit", nullable: true),
        //            LoginActive = table.Column<long>(type: "bigint", nullable: true),
        //            ACTIVEUSER = table.Column<bool>(type: "bit", nullable: true),
        //            USERDATE = table.Column<DateTime>(type: "datetime", nullable: true),
        //            Language1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            Language2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            Language3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            DateOfBirth = table.Column<DateTime>(type: "datetime", nullable: true),
        //            EmployeePosition = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            salary = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            DateOfJoining = table.Column<DateTime>(type: "datetime", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_USER_MST", x => new { x.TenentID, x.USER_ID, x.LOCATION_ID });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "UserPages",
        //        schema: "Membership",
        //        columns: table => new
        //        {
        //            UserWebPageID = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            User_ID = table.Column<int>(type: "int", nullable: true),
        //            WebPage_ID = table.Column<int>(type: "int", nullable: true),
        //            HasInsert = table.Column<bool>(type: "bit", nullable: true),
        //            HasUpdate = table.Column<bool>(type: "bit", nullable: true),
        //            HasDelete = table.Column<bool>(type: "bit", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK__UserPage__D6CACE438595FAC8", x => x.UserWebPageID);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Users",
        //        schema: "Membership",
        //        columns: table => new
        //        {
        //            UserID = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            FullName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
        //            Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
        //            UserName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
        //            Password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
        //            Image = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
        //            IsActive = table.Column<bool>(type: "bit", nullable: true),
        //            CreatedBy = table.Column<int>(type: "int", nullable: true),
        //            CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            UpdatedBy = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            Tanent_ID = table.Column<int>(type: "int", nullable: true),
        //            Location_ID = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Users", x => x.UserID);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "Voucher",
        //        schema: "Accounts",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
        //            LocationID = table.Column<int>(type: "int", nullable: false),
        //            VoucherID = table.Column<int>(type: "int", nullable: false),
        //            VoucherCode = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
        //            FPeriod_ID = table.Column<int>(type: "int", nullable: false),
        //            VoucherType_ID = table.Column<int>(type: "int", nullable: false),
        //            Account_ID = table.Column<int>(type: "int", nullable: true),
        //            VoucherDate = table.Column<DateTime>(type: "date", nullable: false),
        //            IsPosted = table.Column<bool>(type: "bit", nullable: false),
        //            Narrations = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
        //            ReceiverName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
        //            ReferenceNo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            CostCenter_ID = table.Column<int>(type: "int", nullable: true),
        //            UpdatedBy = table.Column<int>(type: "int", nullable: true),
        //            UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            CreatedBy = table.Column<int>(type: "int", nullable: true),
        //            CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            crupid = table.Column<long>(type: "bigint", nullable: true),
        //            OriginalFileName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
        //            FileExtension = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
        //            FileContentType = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
        //            FilePath = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
        //            IsSingleEntry = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Voucher", x => new { x.TenentID, x.LocationID, x.VoucherID });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "VoucherDetail",
        //        schema: "Accounts",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
        //            LocationID = table.Column<int>(type: "int", nullable: false),
        //            VoucherDetailID = table.Column<int>(type: "int", nullable: false),
        //            Voucher_ID = table.Column<int>(type: "int", nullable: false),
        //            Account_ID = table.Column<int>(type: "int", nullable: false),
        //            Amount = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
        //            Dr = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
        //            Cr = table.Column<decimal>(type: "decimal(18,3)", nullable: true),
        //            Particular = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
        //            ChequeNo = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
        //            ChequeDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            IsPaid = table.Column<bool>(type: "bit", nullable: true),
        //            CostCenter_ID = table.Column<int>(type: "int", nullable: true),
        //            ClearedBy = table.Column<int>(type: "int", nullable: true),
        //            ClearedDate = table.Column<DateTime>(type: "date", nullable: true),
        //            ClearedDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_VoucherDetail", x => new { x.TenentID, x.LocationID, x.VoucherDetailID });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "VoucherDetail_History",
        //        schema: "Accounts",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
        //            LocationID = table.Column<int>(type: "int", nullable: false),
        //            VoucherDetailHistoryID = table.Column<long>(type: "bigint", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            HistoryDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            VoucherDetail_ID = table.Column<int>(type: "int", nullable: true),
        //            Voucher_ID = table.Column<int>(type: "int", nullable: false),
        //            Account_ID = table.Column<int>(type: "int", nullable: false),
        //            Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
        //            Particular = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
        //            ChequeNo = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
        //            ChequeDate = table.Column<DateTime>(type: "datetime", nullable: true),
        //            IsPaid = table.Column<bool>(type: "bit", nullable: true),
        //            CostCenter_ID = table.Column<int>(type: "int", nullable: true),
        //            Dr = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
        //            Cr = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
        //            User_ID = table.Column<int>(type: "int", nullable: true),
        //            crupid = table.Column<long>(type: "bigint", nullable: true),
        //            FilePath = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
        //            ClearedBy = table.Column<int>(type: "int", nullable: true),
        //            ClearedDate = table.Column<DateTime>(type: "date", nullable: true),
        //            ClearedDateTime = table.Column<DateTime>(type: "datetime", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_VoucherDetail_History", x => new { x.TenentID, x.LocationID, x.VoucherDetailHistoryID });
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "VoucherTypes",
        //        schema: "Accounts",
        //        columns: table => new
        //        {
        //            VoucherTypeID = table.Column<int>(type: "int", nullable: false),
        //            VoucherName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
        //            ArabicVoucherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            CodePrefix = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_VoucherTypes", x => x.VoucherTypeID);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "WebPages",
        //        schema: "Membership",
        //        columns: table => new
        //        {
        //            WebPageID = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Parent_ID = table.Column<int>(type: "int", nullable: true),
        //            IsVisible = table.Column<bool>(type: "bit", nullable: true),
        //            PageIcon = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
        //            PageOrder = table.Column<int>(type: "int", nullable: true),
        //            PageTitle = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
        //            ControllerName = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
        //            ViewName = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
        //            Description = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: true),
        //            ArabicPageTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_WebPages", x => x.WebPageID);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "WebPageUrls",
        //        schema: "Membership",
        //        columns: table => new
        //        {
        //            WebPageUrlID = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            WebPage_ID = table.Column<int>(type: "int", nullable: true),
        //            Url = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_WebPageUrls", x => x.WebPageUrlID);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "FormTitleDT",
        //        columns: table => new
        //        {
        //            TenentID = table.Column<int>(type: "int", nullable: false),
        //            FormID = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Make sure you are not using any special character here"),
        //            Language = table.Column<int>(type: "int", nullable: false, comment: "1= English 2=Arabic you can take from reftable refsubtype='Language'"),
        //            LabelID = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
        //            Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true, comment: "English or Arabic Text"),
        //            ArabicTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true, comment: "English or Arabic Text"),
        //            RL = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true, comment: " RL=Right to left or LR=Left to Right"),
        //            Attiribute = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "incase color or any special effect u want to apply thru this"),
        //            Remarks = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //            Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
        //            FormTitleHdFormId = table.Column<string>(type: "nvarchar(40)", nullable: false),
        //            FormTitleHdLanguage = table.Column<int>(type: "int", nullable: false),
        //            FormTitleHdTenentId = table.Column<int>(type: "int", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_FormTitleDT_1", x => new { x.TenentID, x.FormID, x.Language, x.LabelID });
        //            table.ForeignKey(
        //                name: "FK_FormTitleDT_FormTitleHD_FormTitleHdTenentId_FormTitleHdFormId_FormTitleHdLanguage",
        //                columns: x => new { x.FormTitleHdTenentId, x.FormTitleHdFormId, x.FormTitleHdLanguage },
        //                principalTable: "FormTitleHD",
        //                principalColumns: new[] { "TenentID", "FormID", "Language" },
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateTable(
        //        name: "TestEmployees",
        //        columns: table => new
        //        {
        //            Id = table.Column<int>(type: "int", nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //            CompanyId = table.Column<int>(type: "int", nullable: true)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_TestEmployees", x => x.Id);
        //            table.ForeignKey(
        //                name: "FK_TestEmployees_TestCompanies_CompanyId",
        //                column: x => x.CompanyId,
        //                principalTable: "TestCompanies",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Restrict);
        //        });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_DetailedEmployee",
        //        table: "DetailedEmployee",
        //        columns: new[] { "TenentID", "PFID" });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_FormTitleDT_FormTitleHdTenentId_FormTitleHdFormId_FormTitleHdLanguage",
        //        table: "FormTitleDT",
        //        columns: new[] { "FormTitleHdTenentId", "FormTitleHdFormId", "FormTitleHdLanguage" });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_TBLCOMPANYSETUP_Mob",
        //        table: "TBLCOMPANYSETUP",
        //        columns: new[] { "TenentID", "MYCONLOCID", "ALTMOBPHONE" });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_TBLCOMPANYSETUPCompName",
        //        table: "TBLCOMPANYSETUP",
        //        columns: new[] { "TenentID", "MYCONLOCID", "COMPNAME1", "COMPNAME2", "COMPNAME3" });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_TBLCOMPANYSETUPCountStatCity",
        //        table: "TBLCOMPANYSETUP",
        //        columns: new[] { "TenentID", "MYCONLOCID", "COUNTRYID", "STATE", "CITY" });

        //    migrationBuilder.CreateIndex(
        //        name: "TBLCOMPANYSETUP",
        //        table: "TBLCOMPANYSETUP",
        //        columns: new[] { "TenentID", "MYCONLOCID", "COMPNAME1", "ALTMOBPHONE", "COMPID" },
        //        unique: true,
        //        filter: "[MYCONLOCID] IS NOT NULL AND [COMPNAME1] IS NOT NULL AND [ALTMOBPHONE] IS NOT NULL");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_TestEmployees_CompanyId",
        //        table: "TestEmployees",
        //        column: "CompanyId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_University_Mob",
        //        table: "University",
        //        columns: new[] { "TenentID", "MYCONLOCID", "ALTMOBPHONE" });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_UniversityCountStatCity",
        //        table: "University",
        //        columns: new[] { "TenentID", "MYCONLOCID", "COUNTRYID", "STATE", "CITY" });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_UniversityUnivName",
        //        table: "University",
        //        columns: new[] { "TenentID", "MYCONLOCID", "UnivName1", "UnivName2", "UnivName3" });

        //    migrationBuilder.CreateIndex(
        //        name: "University",
        //        table: "University",
        //        columns: new[] { "TenentID", "MYCONLOCID", "UnivName1", "ALTMOBPHONE", "UnivIDByUser" },
        //        unique: true,
        //        filter: "[MYCONLOCID] IS NOT NULL AND [UnivName1] IS NOT NULL AND [ALTMOBPHONE] IS NOT NULL");
        //}

        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropTable(
        //        name: "'Total JV$'");

        //    migrationBuilder.DropTable(
        //        name: "AccountHead",
        //        schema: "Accounts");

        //    migrationBuilder.DropTable(
        //        name: "AccountTypes",
        //        schema: "Accounts");

        //    migrationBuilder.DropTable(
        //        name: "ChequeBooks",
        //        schema: "Accounts");

        //    migrationBuilder.DropTable(
        //        name: "COA",
        //        schema: "Accounts");

        //    migrationBuilder.DropTable(
        //        name: "CostCenters",
        //        schema: "Accounts");

        //    migrationBuilder.DropTable(
        //        name: "CRUP_MST");

        //    migrationBuilder.DropTable(
        //        name: "CRUPAudit");

        //    migrationBuilder.DropTable(
        //        name: "DeletedVoucher",
        //        schema: "Accounts");

        //    migrationBuilder.DropTable(
        //        name: "DetailedEmployee");

        //    migrationBuilder.DropTable(
        //        name: "DetailedEmployee_Import");

        //    migrationBuilder.DropTable(
        //        name: "DrCrTemplate",
        //        schema: "Accounts");

        //    migrationBuilder.DropTable(
        //        name: "FAAccountGroup");

        //    migrationBuilder.DropTable(
        //        name: "FAActIntegSetup");

        //    migrationBuilder.DropTable(
        //        name: "FAActPredGroup");

        //    migrationBuilder.DropTable(
        //        name: "FACashBankMaster");

        //    migrationBuilder.DropTable(
        //        name: "FAChequeBook");

        //    migrationBuilder.DropTable(
        //        name: "FACostCenter");

        //    migrationBuilder.DropTable(
        //        name: "FAGLAccount");

        //    migrationBuilder.DropTable(
        //        name: "Families",
        //        schema: "Accounts");

        //    migrationBuilder.DropTable(
        //        name: "FASLAccount");

        //    migrationBuilder.DropTable(
        //        name: "FinancialPeriod",
        //        schema: "Accounts");

        //    migrationBuilder.DropTable(
        //        name: "FormTitleDT");

        //    migrationBuilder.DropTable(
        //        name: "ICCATSUBCAT");

        //    migrationBuilder.DropTable(
        //        name: "LettersHD");

        //    migrationBuilder.DropTable(
        //        name: "Location");

        //    migrationBuilder.DropTable(
        //        name: "Mapping",
        //        schema: "Accounts");

        //    migrationBuilder.DropTable(
        //        name: "MappingHeads",
        //        schema: "Accounts");

        //    migrationBuilder.DropTable(
        //        name: "MYCOMPANYSETUP");

        //    migrationBuilder.DropTable(
        //        name: "RefLabelMST");

        //    migrationBuilder.DropTable(
        //        name: "REFTABLE");

        //    migrationBuilder.DropTable(
        //        name: "RefTableAdmin");

        //    migrationBuilder.DropTable(
        //        name: "ServiceSetup");

        //    migrationBuilder.DropTable(
        //        name: "SubHead",
        //        schema: "Accounts");

        //    migrationBuilder.DropTable(
        //        name: "SubSubHead",
        //        schema: "Accounts");

        //    migrationBuilder.DropTable(
        //        name: "tbl_Account_Mst");

        //    migrationBuilder.DropTable(
        //        name: "tblActSLSetup");

        //    migrationBuilder.DropTable(
        //        name: "tblAudit");

        //    migrationBuilder.DropTable(
        //        name: "tblCityStatesCounty");

        //    migrationBuilder.DropTable(
        //        name: "TBLCOMPANYSETUP");

        //    migrationBuilder.DropTable(
        //        name: "TBLCONTACT_DEL_ADRES");

        //    migrationBuilder.DropTable(
        //        name: "tblCOUNTRY");

        //    migrationBuilder.DropTable(
        //        name: "tblDistrictStatesCounty");

        //    migrationBuilder.DropTable(
        //        name: "tblImportCOA");

        //    migrationBuilder.DropTable(
        //        name: "tblImportCOAV2");

        //    migrationBuilder.DropTable(
        //        name: "tblImportVoucher");

        //    migrationBuilder.DropTable(
        //        name: "TBLPERIODS");

        //    migrationBuilder.DropTable(
        //        name: "tblStates");

        //    migrationBuilder.DropTable(
        //        name: "tbltranssubtype");

        //    migrationBuilder.DropTable(
        //        name: "tbltranstype");

        //    migrationBuilder.DropTable(
        //        name: "TestEmployees");

        //    migrationBuilder.DropTable(
        //        name: "TestTable");

        //    migrationBuilder.DropTable(
        //        name: "TransactionDT");

        //    migrationBuilder.DropTable(
        //        name: "TransactionHD");

        //    migrationBuilder.DropTable(
        //        name: "TransactionHDDApprovalDetails  ");

        //    migrationBuilder.DropTable(
        //        name: "TransactionHDDMS ");

        //    migrationBuilder.DropTable(
        //        name: "TreeFunction");

        //    migrationBuilder.DropTable(
        //        name: "TreeNode");

        //    migrationBuilder.DropTable(
        //        name: "University");

        //    migrationBuilder.DropTable(
        //        name: "USER_DTL");

        //    migrationBuilder.DropTable(
        //        name: "USER_MST");

        //    migrationBuilder.DropTable(
        //        name: "UserPages",
        //        schema: "Membership");

        //    migrationBuilder.DropTable(
        //        name: "Users",
        //        schema: "Membership");

        //    migrationBuilder.DropTable(
        //        name: "Voucher",
        //        schema: "Accounts");

        //    migrationBuilder.DropTable(
        //        name: "VoucherDetail",
        //        schema: "Accounts");

        //    migrationBuilder.DropTable(
        //        name: "VoucherDetail_History",
        //        schema: "Accounts");

        //    migrationBuilder.DropTable(
        //        name: "VoucherTypes",
        //        schema: "Accounts");

        //    migrationBuilder.DropTable(
        //        name: "WebPages",
        //        schema: "Membership");

        //    migrationBuilder.DropTable(
        //        name: "WebPageUrls",
        //        schema: "Membership");

        //    migrationBuilder.DropTable(
        //        name: "FormTitleHD");

        //    migrationBuilder.DropTable(
        //        name: "TestCompanies");
        //}
    }
}
