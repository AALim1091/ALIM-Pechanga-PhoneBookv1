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
            public async Task<IActionResult> GetAllEmployees()
                {
                List<Employees> emps = new List<Employees>();
                try
                {
                    emps = await _context.e.ToListAsync();
                    //emps.Where(x => x.Department == "blarg").ToListAsync();

                }
                catch (Exception e)
                {
                    string exceptionMessage = e.Message;
                }
                return Ok(emps);

            }

            //FETCH DETAILS OF ONE EMPLPOYEE THAT MATCHES PASSED ID AS PARAMETER
            [HttpGet("{id}")]
            public async Task<IActionResult> Get(int id)
            {
                var emp = await _context.e.FirstOrDefaultAsync(a => a.Id == id);
                return Ok(emp);
            }

        ////FETCH DETAILS OF ONE EMPLPOYEE THAT MATCHES PASSED ID AS PARAMETER
        //[HttpGet("{id}")]
        //[Route("GetEmployeeByID")]
        //public async Task<IActionResult> GetEmployeeByID(int id)
        //{
        //    var emp = await _context.e.FirstOrDefaultAsync(a => a.Id == id);
        //    return Ok(emp);
        //}

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
            public async Task<IActionResult> CreateEmployee(Employees it)
            {
                _context.Add(it);
            //if(it.JobTitle == "VP")
            //{
            //    it.titlerank = 1;
            //}
            //else if(it.JobTitle = "")
            //            {

            //}
                await _context.SaveChangesAsync();
                return Ok(it.Id);
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
            public async Task<IActionResult> Editemployee(Employees it)
            {
                _context.Entry(it).State = EntityState.Modified;
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
