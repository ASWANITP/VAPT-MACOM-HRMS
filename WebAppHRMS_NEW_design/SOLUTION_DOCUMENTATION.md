# WebAppHRMS Solution Documentation

## Project Overview
**WebAppHRMS** is a comprehensive Human Resource Management System built using ASP.NET Web Forms with VB.NET. The application manages various HR functions including employee management, leave management, attendance tracking, payroll processing, and reporting.

## Technical Architecture

### Technology Stack
- **Framework**: ASP.NET Web Forms (.NET Framework 4.8)
- **Language**: VB.NET
- **Database**: Oracle Database with Oracle.ManagedDataAccess
- **Reporting**: Crystal Reports 13.0
- **UI Components**: AjaxControlToolkit, CalendarExtenderPlus
- **Document Processing**: GemBox.Document, PDFsharp
- **Additional Libraries**: SkiaSharp, HarfBuzzSharp, Entity Framework 6.5.1

### Project Structure
```
WebAppHRMS/
├── App_Code/           # Shared code classes
├── Assets/             # Static assets (images, CSS, JS)
├── BLL/               # Business Logic Layer
├── DAL/               # Data Access Layer
├── IDAL/              # Interface Data Access Layer
├── attendance/        # Attendance management modules
├── leave/             # Leave management system
├── payroll/           # Payroll processing
├── HRM/               # Core HR modules
├── general/           # General utilities
├── control/           # Custom controls
├── script/            # JavaScript files
└── bin/               # Compiled assemblies
```

## Core Modules

### 1. Leave Management System (`/leave/`)
Comprehensive leave management with multiple sub-modules:

#### Features:
- **Leave Application**: Standard leave requests and approvals
- **Compensatory Leave**: Overtime compensation management
- **Early Going**: Early departure requests
- **Maternity Leave**: Specialized maternity leave handling
- **Leave Reports**: Various reporting capabilities

#### Key Components:
- `HRM_LEAVE_APPLICATION.aspx` - Main leave application form
- `Leave_sanction_New.aspx` - Leave approval workflow
- `Leave_Cancel.aspx` - Leave cancellation
- `rpt_leave_applied_status.aspx` - Leave status reporting
- `leave_enquiry.aspx` - Leave balance inquiries

### 2. Attendance Management (`/attendance/`)
Employee attendance tracking and management system.

### 3. Payroll System (`/payroll/`)
Salary processing and payroll management.

### 4. HRM Core (`/HRM/`)
Core human resource management functions including employee master data.

### 5. General Utilities (`/general/`)
Common utilities and shared functionality across modules.

## Security Configuration

### Web.config Security Headers
```xml
<httpProtocol>
  <customHeaders>
    <add name="X-Content-Type-Options" value="nosniff" />
    <add name="X-Frame-Options" value="DENY" />
    <add name="X-XSS-Protection" value="1; mode=block" />
    <add name="Referrer-Policy" value="strict-origin-when-cross-origin" />
    <add name="Cache-Control" value="no-cache, no-store, must-revalidate, private" />
  </customHeaders>
</httpProtocol>
```

### HTTP Method Restrictions
- Allowed: GET, POST
- Blocked: PUT, DELETE, HEAD, OPTIONS, TRACE, CONNECT, PATCH

### Session Management
- InProc session state
- 30-minute timeout
- HTTP-only cookies
- Session ID regeneration

## Database Configuration

### Oracle Database Setup
- **Provider**: Oracle.ManagedDataAccess.Client
- **Version**: 4.122.23.1
- **Connection**: Configured through Helper.Oracle.OracleHelper

### Key Database Components
- Employee master tables
- Leave management tables
- Attendance tracking tables
- Payroll processing tables
- User authentication tables

## Authentication & Authorization

### Login System (`Main.aspx`)
- User ID validation (5-6 digits)
- Password validation (6-50 characters)
- IP address restrictions
- Branch-based access control
- Session management

### Access Control
- Role-based permissions
- Branch-level security
- Employee hierarchy validation

## Reporting System

### Crystal Reports Integration
- Version 13.0 implementation
- Multiple report formats
- Leave reports, attendance reports, payroll reports
- Export capabilities (PDF, Excel)

### Key Reports
- Leave application reports
- Leave balance reports
- Attendance summaries
- Payroll statements
- Holiday registers

## Development Guidelines

### Code Structure
- **BLL (Business Logic Layer)**: Contains business rules and logic
- **DAL (Data Access Layer)**: Database operations and queries
- **IDAL (Interface DAL)**: Abstraction layer for data access
- **Helper Classes**: Utility functions and common operations

### Naming Conventions
- Pages: `ModuleName_Function.aspx`
- Classes: PascalCase
- Methods: PascalCase
- Variables: camelCase

### Error Handling
- Custom error pages
- Logging mechanisms
- User-friendly error messages
- Debug mode configuration

## Deployment Configuration

### IIS Settings
- .NET Framework 4.8 required
- Crystal Reports runtime required
- Oracle client libraries
- Appropriate file permissions

### Dependencies
All NuGet packages are managed through packages.config:
- AjaxControlToolkit 20.1.0
- Crystal Reports components
- Oracle.ManagedDataAccess 23.7.0
- Entity Framework 6.5.1
- Various supporting libraries

## Maintenance & Support

### Regular Maintenance Tasks
- Database backup and maintenance
- Log file cleanup
- Session cleanup
- Performance monitoring

### Monitoring Points
- Database connection health
- Session management
- Error rates
- Performance metrics

## Security Considerations

### Current Security Measures
- Input validation
- SQL injection prevention through parameterized queries
- XSS protection headers
- Session security
- Access control validation

### Recommended Enhancements
- Implement HTTPS enforcement
- Add CSRF protection
- Enhance password policies
- Implement audit logging
- Add rate limiting

## Integration Points

### External Systems
- Oracle Database
- Crystal Reports Server
- Email systems (for notifications)
- File storage systems

### API Endpoints
- Internal callback mechanisms
- Report generation services
- Data export functions

## Performance Optimization

### Current Optimizations
- ViewState management
- Caching strategies
- Database connection pooling
- Compressed resources

### Monitoring Metrics
- Page load times
- Database query performance
- Memory usage
- Concurrent user capacity

## Backup & Recovery

### Backup Strategy
- Database backups
- Application file backups
- Configuration backups
- Log file archival

### Recovery Procedures
- Database restoration
- Application deployment
- Configuration restoration
- Data validation

---

**Document Version**: 1.0  
**Last Updated**: Current Date  
**Maintained By**: Development Team