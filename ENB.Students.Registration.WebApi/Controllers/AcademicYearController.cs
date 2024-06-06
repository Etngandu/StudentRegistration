using ENB.Students.Registration.Infrastucture;
using ENB.Students.Registration.WebApi.Commands.CreateAcademicYear;
using ENB.Students.Registration.WebApi.Models;
using ENB.Students.Registration.WebApi.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ENB.Students.Registration.Mvc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcademicYearController : ControllerBase
    {
        private readonly ISender _sender;

        public AcademicYearController(ISender sender)
        {
            _sender = sender;
        }

        // GET: AcademicYearController
        [HttpGet]
        [Route("GetListAcademicY")]

        public async Task<IActionResult> GetListAcademicY(CancellationToken cancellationToken)
        {

            var listAcademicyear= await _sender.Send(new GetAcademicYearsQuery(),cancellationToken);

            return Ok(listAcademicyear);


        }


        // GET: AcademicYearController/Details/5

        [HttpGet]
        [Route("details/{id}")]
        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        { 
            var academicyear= await _sender.Send(new GetAcademicYearByIdQuery(id),cancellationToken);

            return Ok(academicyear);
        }




       // POST: AcademicYearController/Create
       [HttpPost]
       [Route("createAcademicYear")]
        public async Task<IActionResult> Create([FromBody] CreateAndEditAcademicYear createAndEditAcademicYear,CancellationToken cancellationToken)
        {
           
            var academicYearToReturn = await _sender.Send(new CreateAcademicYearCommand(createAndEditAcademicYear),cancellationToken);

            return CreatedAtAction(nameof(Details), new { id = academicYearToReturn.Id }, academicYearToReturn);
        }

        // POST: AcademicYearController/Edit
        [HttpPut]
        [Route("EditAcademicYear")]
        public async Task<IActionResult> Edit([FromBody] CreateAndEditAcademicYear createAndEditAcademicYear,CancellationToken cancellationToken)
        {
            var academicYearToReturn = await _sender.Send(new EditAcademicYearCommand(createAndEditAcademicYear),cancellationToken);

            return CreatedAtAction(nameof(Details), new { id = academicYearToReturn.Id }, academicYearToReturn);
        }



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Save(CreateAndEditAcademicYear  createAndEditAcademicYear)
        //{   

        //    if (createAndEditAcademicYear.Id == 0)
        //    {
        //         await  _sender.Send(new CreateAcademicYearCommand(createAndEditAcademicYear));

        //      return  RedirectToAction(nameof(Index));
        //    }
        //    else
        //    {
        //        await _sender.Send(new EditAcademicYearCommand(createAndEditAcademicYear));

        //      return  RedirectToAction(nameof(Index));
        //    }           


        //}

        //// POST: AcademicYearController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: AcademicYearController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: AcademicYearController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
