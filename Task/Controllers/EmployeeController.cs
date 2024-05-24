using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Task.BL.Interface;
using Task.BL.Model;
using Task.DAL.DataBase;
using Task.DAL.Entity;

namespace Task.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly TaskContext context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(TaskContext context, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var data = _unitOfWork.Employees.GetAll();
            var result = _mapper.Map<IEnumerable<EmployeeVM>>(data);

            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var employee = _mapper.Map<Employee>(model);
                // add
                await _unitOfWork.Employees.Add(employee);
                // save
                 _unitOfWork.Complete();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }


        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _unitOfWork.Employees.GetById(id);
            if (employee == null)
                return NotFound();

            var model = _mapper.Map<EmployeeVM>(employee);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EmployeeVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var employee = await _unitOfWork.Employees.GetById(id);
                if (employee == null)
                    return NotFound();

                _mapper.Map(model, employee);

                // update data
                _unitOfWork.Employees.Update(employee);
                // save 
                 _unitOfWork.Complete();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _unitOfWork.Employees.GetById(id);
            if (employee == null)
                return NotFound();

            var model = _mapper.Map<EmployeeVM>(employee);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var employee = await _unitOfWork.Employees.GetById(id);
                if (employee == null)
                    return NotFound();
                // remove
                _unitOfWork.Employees.Delete(employee);
                // save 
                 _unitOfWork.Complete();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }
    }
}
