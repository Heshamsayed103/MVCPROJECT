using Company.G04.BLL.Interfaces;
using Company.G04.BLL.Repositories;
using Company.G04.DAL.Models;
using Company.G04.PL.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Threading.Tasks;

namespace Company.G04.PL.Controllers
{
    [Authorize]

    //MVC Controller
    public class DepartmentController : Controller
    {
       // private readonly IDepartmentRepository _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        //ASK  CLR Create Object From DepartmentRepository
        public DepartmentController(/*IDepartmentRepository departmentRepository*/IUnitOfWork unitOfWork)
        {
           // _departmentRepository = departmentRepository;
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet] //Get: /Department/Index
        public async Task<IActionResult> Index()
        {
            var departments = await _unitOfWork.DepartmentRepository.GetAllAsync();

            return View(departments);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDepartmentDto model)
        {
           if(ModelState.IsValid) //Server Side Validation
           {
                var department = new Department()//Manul Mapping
                {
                    Code=model.Code,
                    Name=model.Name,
                    CreateAt=model.CreateAt
                };
                 
                await _unitOfWork.DepartmentRepository.AddAsync(department);
                var count = await _unitOfWork.CompleteAsync();
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
           }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) return BadRequest("Invalid Id");//400
           
            var department = await _unitOfWork.DepartmentRepository.GetAsync(id.Value);
            if (department is null) return NotFound(new { StatusCode = 404, Message = $"Department With Id :{id} is not found" });

            return View(department);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest("Invalid Id");//400

            var department =await _unitOfWork.DepartmentRepository.GetAsync(id.Value);
            if (department is null) return NotFound(new { StatusCode = 404, Message = $"Department With Id :{id} is not found" });

            var dto = new CreateDepartmentDto
            { 
                Code=department.Code,
                Name=department.Name,
                CreateAt=department.CreateAt
            };

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Edit([FromRoute] int id, CreateDepartmentDto model)
        {
            if (ModelState.IsValid)
            {
                var department = new Department()//Manul Mapping
                {
                    Id=id,
                    Code = model.Code,
                    Name = model.Name,
                    CreateAt = model.CreateAt
                };
                 _unitOfWork.DepartmentRepository.Update(department);
                var count =await _unitOfWork.CompleteAsync();

                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }


        //[HttpPost]
        ////[ValidateAntiForgeryToken] 
        //public IActionResult Edit([FromRoute] int id, UpdateDepartmentDto model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var department = new Department()
        //        {
        //            Id=id,
        //            Name= model.Name,
        //            Code= model.Code,
        //            CreateAt= model.CreateAt
        //        };
        //        var count = _departmentRepository.Update(department);
        //        if (count > 0)
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //    }
        //    return View(model);
        //}


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest("invalid id");//400

            var department = await _unitOfWork.DepartmentRepository.GetAsync(id.Value);
            if (department is null) return NotFound(new { statuscode = 404, message = $"department with id :{id} is not found" });
          
            var dto = new CreateDepartmentDto()
            {
                Name= department.Name,
                Code= department.Code,
                CreateAt=department.CreateAt
            };
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Delete([FromRoute] int id , CreateDepartmentDto model)
        {
            if (ModelState.IsValid)
            {
                var department = new Department()
                {
                    Id = id,
                    Name = model.Name,
                    Code = model.Code,
                    CreateAt = model.CreateAt
                };
                _unitOfWork.DepartmentRepository.Delete(department);
                var count = await _unitOfWork.CompleteAsync();
                //await _unitOfWork.DepartmentRepository.Delete(department);

                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
              return View(model);
        }




    }
}
