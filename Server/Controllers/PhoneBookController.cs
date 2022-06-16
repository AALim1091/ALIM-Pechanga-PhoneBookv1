using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneBookv1.Server.Data;
using PhoneBookv1.Shared.Models;

namespace PhoneBookv1.Server.Controllers 
{
    //API CONTROLLER
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBookController : ControllerBase
        {
            private readonly ApplicationDBContext _context;
            public PhoneBookController(ApplicationDBContext context)
            {
                _context = context;
            }


            ////ACTION METHOD TO GET ALL EMPLOYEES FROM CONTEXT INSTANCE
            //[HttpGet]
            //public async Task<IActionResult> Get()
            //{
            //    List<Employees> emps = new List<Employees>();
            //    try
            //    {
            //        emps = await _context.e.ToListAsync();
                    
            //    }
            //    catch(Exception e)
            //    {
            //        string exceptionMessage = e.Message;
            //    }
            //    return Ok(emps);

            //}

            //ACTION METHOD TO GET ALL EMPLOYEES FROM CONTEXT INSTANCE
            [HttpGet]
            [Route("GetAllEmployees")]
            public async Task<IActionResult> GetAllEmployees(string fName, string lName, string phoneExt, string phone, string mobilePhone, string department)
            {
                List<Employees> emps = new List<Employees>();
                try
                {
                    emps = await _context.employees.Where(x =>
                   (fName == null || x.FirstName.ToUpper().Contains(fName.ToUpper()))
                   && (lName == null || x.LastName.ToUpper().Contains(lName.ToUpper()))
                   && (phoneExt == null || x.PhoneExtension.ToUpper().Contains(phoneExt.ToUpper()))
                   && (phone == null || x.PhoneNumber.ToUpper().Contains(phone.ToUpper()))
                   && (mobilePhone == null || x.MobilePhoneNumber.ToUpper().Contains(mobilePhone.ToUpper()))
                   && (department == null || x.Department.ToUpper().Contains(department.ToUpper()))
                   ).OrderBy(e => e.Department).ThenBy(e => e.TitleRank).ThenBy(e => e.LastName).ToListAsync();
                //emps = await _context.employees.OrderBy(e => e.Department).ThenBy(e => e.TitleRank).ThenBy(e => e.LastName).ToListAsync();
                //emps = await _context.employees.ToListAsync();
                //emps.Where(x => x.Department == "blarg").ToListAsync();

            }
                catch (Exception e)
                {
                    string exceptionMessage = e.Message;
                }
                return Ok(emps);

            }

            ////FETCH DETAILS OF ONE EMPLPOYEE THAT MATCHES PASSED ID AS PARAMETER
            //[HttpGet("{id}")]
            //public async Task<IActionResult> Get(int id)
            //{
            //    var emp = await _context.employees.FirstOrDefaultAsync(a => a.Id == id);
            //    return Ok(emp);
            //}

            //FETCH DETAILS OF ONE EMPLPOYEE THAT MATCHES PASSED ID AS PARAMETER
            [HttpGet("{id}")]
            [Route("GetEmployeeByID/{empId?}")]
            public async Task<IActionResult> GetEmployeeByID(int id)
            {
                var emp = await _context.employees.FirstOrDefaultAsync(a => a.Id == id);
                return Ok(emp);
            }

            ////Search for Employee based on FirstName, LastName, PhoneExtension, & PhoneNumber
            ////Need to use this when improving search implementation (Not used right now)
            //[HttpGet("{searchText}")]
            //public async Task<IActionResult> SearchEmployee(string searchText)
            //{
            //    var emp = await _context.ITtable
            //    .Where(a => a.FirstName.Contains(searchText) || a.LastName.Contains(searchText) || a.PhoneExtension.Contains(searchText) || a.PhoneNumber.Contains(searchText)).ToListAsync();
            //    return Ok(emp);

            //}

            //CREATE NEW EMPLOYEE IN TABLE
            //[HttpPost]
            //public async Task<IActionResult> Post(Employees it)
            //{
            //    _context.Add(it);
            //    await _context.SaveChangesAsync();
            //    return Ok(it.Id);
            //}


            //CREATE NEW EMPLOYEE IN TABLE
            [HttpPost]
            [Route("CreateEmployee")]
            public async Task<IActionResult> CreateEmployee(Employees cEmployee)
            {
                _context.Add(cEmployee);
                cEmployee.JobTitle = cEmployee.JobTitle.ToUpper();
                cEmployee.Department = cEmployee.Department.ToUpper();
                
                //note to self: Add functionality for duplicate employeeIDs as well
                //IF employeeID is negative 
                if(cEmployee.EmployeeId < 0)
                {
                    cEmployee.EmployeeId = 0;
                }


                if (cEmployee.JobTitle.Contains("VP"))
                {
                    cEmployee.TitleRank = 1;
                }
                else if(cEmployee.JobTitle.Contains("DIRECTOR") && !cEmployee.JobTitle.ToUpper().Contains("ASSISTANT DIRECTOR"))
                {
                    cEmployee.TitleRank = 2;
                }
                else if (cEmployee.JobTitle.Contains("ASSISTANT DIRECTOR"))
                {
                    cEmployee.TitleRank = 3;
                }
                else if (cEmployee.JobTitle.Contains("MANAGER") && !cEmployee.JobTitle.ToUpper().Contains("ASSISTANT MANAGER"))
                {
                    cEmployee.TitleRank = 4;
                }
                else if (cEmployee.JobTitle.Contains("ASSISTANT MANAGER"))
                {
                    cEmployee.TitleRank = 5;
                }
                else if (cEmployee.JobTitle.Contains("SUPERVISOR"))
                {
                    cEmployee.TitleRank = 6;
                }
                else
                {
                    cEmployee.TitleRank = 7;
                }
                await _context.SaveChangesAsync();
                    return Ok(cEmployee.Id);
            }

            ////MODIFIES EXISITING EMPLOYEE
            //[HttpPut]
            //public async Task<IActionResult> Put(Employees it)
            //{
            //    _context.Entry(it).State = EntityState.Modified;
            //    await _context.SaveChangesAsync();
            //    return NoContent();
            //}

            //MODIFIES EXISITING EMPLOYEE
            [HttpPut]
            [Route("EditEmployee")]
            public async Task<IActionResult> Editemployee(Employees eEmployee)
            {
                eEmployee.JobTitle = eEmployee.JobTitle.ToUpper();
                eEmployee.Department = eEmployee.Department.ToUpper();
                _context.Entry(eEmployee).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }


            //DELETES USER BY ID
            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var emp = new Employees { Id = id };
                _context.Remove(emp);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
}
