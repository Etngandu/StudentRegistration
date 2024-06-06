using AspNetCoreHero.ToastNotification.Abstractions;
using ENB.Students.Registration.Entities;
using ENB.Students.Registration.Infrastucture;
using ENB.Students.Registration.Mvc.Commands.CreateAcademicYear;
using ENB.Students.Registration.Mvc.Models;
using ENB.Students.Registration.Mvc.Queries;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


namespace ENB.Students.Registration.Mvc.Controllers
{
    public class AcademicYearController : ApiController
    {
        private readonly ISender _sender;
        private readonly INotyfService _notyf;       

        public AcademicYearController(ISender sender, INotyfService notyfService)
        {
            _sender = sender;
            _notyf = notyfService;
        }

        // GET: AcademicYearController
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetListAcademicY()
        {

            var listAcademicyear= await _sender.Send(new GetAcademicYearsQuery());

            return Json(new { data = listAcademicyear });


        }


        // GET: AcademicYearController/Details/5
        public async Task<IActionResult> Details(int id)
        { 
            var academicyear= await _sender.Send(new GetAcademicYearByIdQuery(id));

            return View(academicyear);
        }
            

        // GET: AcademicYearController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AcademicYearController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] CreateAndEditAcademicYear createAndEditAcademicYear)
        {
            try
            {
                var academicYearToReturn = await _sender.Send(new CreateAcademicYearCommand(createAndEditAcademicYear));

                return CreatedAtRoute("Edit", new { id = academicYearToReturn.Value.Id }, academicYearToReturn);
            }
            catch (ModelValidationException mvex)
            {

                foreach (var error in mvex.ValidationErrors)
                 {
                       ModelState.AddModelError(error.MemberNames.FirstOrDefault() ?? "", error.ErrorMessage!);
                 }
            }


            return View();
        }

        // GET: AcademicYearController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(CreateAndEditAcademicYear   createAndEditAcademicYear )
        {

            if (createAndEditAcademicYear.Id == 0)
            {

                ErrorOr<CreateAndEditAcademicYear> addYearToResult = await _sender.Send(new CreateAcademicYearCommand(createAndEditAcademicYear));


                if (addYearToResult.IsError)
                {
                    foreach (var error in addYearToResult.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description!);
                    }

                    return View("Index");// return RedirectToAction("Index", "AcademicYear");
                }
                else 
                {
                    _notyf.Success("Process Created  Successfully! ");
                    return View("Index");
                }
            }
            else 
            {
               // await _sender.Send(new EditAcademicYearCommand(createAndEditAcademicYear));
                ErrorOr<CreateAndEditAcademicYear> editYearToResult = await _sender.Send(new EditAcademicYearCommand(createAndEditAcademicYear));
                if (editYearToResult.IsError)
                {
                    foreach (var error in editYearToResult.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description!);
                    }

                    return View("Index");// return RedirectToAction("Index", "AcademicYear");
                }
                else 
                {
                    _notyf.Success("Process Updated  Successfully! ");
                    return View("Index");
                }

            }           

            
           
        }

        // POST: AcademicYearController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AcademicYearController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AcademicYearController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Error(string messagesJson="")
        {
            var errorMessages = JsonConvert.DeserializeObject<AppErrorViewModel>(messagesJson);
            ViewBag.errorMessages = errorMessages;

            return View();
        }
    }
}
