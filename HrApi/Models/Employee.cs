using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HrApi.Models
{
    public class Region
    {
        [Key]
        [Column("region_id")]
        public int RegionId { get; set; }

        [Column("region_name")]
        public string? RegionName { get; set; }
    }

    public class Country
    {
        [Key]
        [Column("country_id")]
        public string CountryId { get; set; } // Primary key

        [Column("country_name")]
        public string? CountryName { get; set; }

        [Column("region_id")]
        public int RegionId { get; set; }

        [ForeignKey("RegionId")]
        public Region Region { get; set; }
    }

    public class Location
    {
        [Key]
        [Column("location_id")]
        public int LocationId { get; set; }

        [Column("street_address")]
        public string? StreetAddress { get; set; }

        [Column("postal_code")]
        public string? PostalCode { get; set; }

        [Column("city")]
        public string City { get; set; }

        [Column("state_province")]
        public string? StateProvince { get; set; }

        [Column("country_id")]
        public string CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }
    }

    public class Job
    {
        [Key]
        [Column("job_id")]
        public int JobId { get; set; }

        [Column("job_title")]
        public string JobTitle { get; set; }

        [Column("min_salary")]
        public decimal? MinSalary { get; set; }

        [Column("max_salary")]
        public decimal? MaxSalary { get; set; }
    }

    public class Department
    {
        [Key]
        [Column("department_id")]
        public int DepartmentId { get; set; }

        [Column("department_name")]
        public string DepartmentName { get; set; }

        [Column("location_id")]
        public int? LocationId { get; set; }

        [ForeignKey("LocationId")]
        public Location? Location { get; set; }
    }

    public class Employee
    {
        [Key]
        [Column("employee_id")]
        public int EmployeeId { get; set; }

        [Column("first_name")]
        public string? FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("phone_number")]
        public string? PhoneNumber { get; set; }

        [Column("hire_date")]
        public DateTime HireDate { get; set; }

        [Column("job_id")]
        public int JobId { get; set; }

        [ForeignKey("JobId")]
        public Job Job { get; set; }

        [Column("salary")]
        public decimal Salary { get; set; }

        [Column("manager_id")]
        public int? ManagerId { get; set; }

        [ForeignKey("ManagerId")]
        public Employee? Manager { get; set; }

        [Column("department_id")]
        public int? DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }
    }

    public class Dependent
    {
        [Key]
        [Column("dependent_id")]
        public int DependentId { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("relationship")]
        public string Relationship { get; set; }

        [Column("employee_id")]
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}