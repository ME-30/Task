using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.BL.Interface;
using Task.BL.Model;
using Task.DAL.Entity;

namespace Task.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController( IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetEmployee()
        {
            try
            {
                var data = _unitOfWork.Employees.GetAll();
                var result = _mapper.Map<IEnumerable<EmployeeVM>>(data);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneEmp(int id)
        {
            var data = await _unitOfWork.Employees.GetById(id);
            var result = _mapper.Map<EmployeeVM>(data);

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> PostEmployee(EmployeeVM model)
        {

            if (ModelState.IsValid)
            {
                var data = _mapper.Map<Employee>(model);
                await _unitOfWork.Employees.Add(data);
                _unitOfWork.Complete();
                return StatusCode(201, model);
            }

            return BadRequest(ModelState);
        }
        [HttpPut("{id:int}")]
        public IActionResult PutEmployee(int id ,EmployeeVM model)
        {
            if(model != null)
            {
                var data = _mapper.Map<Employee>(model);
                _unitOfWork.Employees.Update(data);
                _unitOfWork.Complete();
                return Ok(model); 
            }
            return BadRequest(ModelState);
            
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmp (int id)
        {
            try { 
            var data = await _unitOfWork.Employees.GetById(id);
            if (data == null)
            {
                return NotFound("Data not found.");
            }

            _unitOfWork.Employees.Delete(data);
            _unitOfWork.Complete();
            return StatusCode(204, "Data Remove");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }
    }
}
