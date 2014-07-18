using System;
using System.Linq;
using System.Web.Http;
using SimpleCookBook.Api.Models;
using System.Net.Http;
using System.Net;
using SimpleCookBook.Models;

namespace SimpleCookBook.Api.Controllers
{
    public class NotesController : BaseApiController
    {
        [HttpGet]
        public IQueryable<NoteFullViewModel> GetAll(string deviceId)
        {
            var response = this.PerformOperationAndHandleExceptions(() => 
            {
                return this.Data.Notes.All().Where(x => x.DeviceId == deviceId).OrderByDescending(x => x.PostDate).Select(NoteFullViewModel.FromNote);
            });

            return response;
        }

        [HttpGet]
        public NoteFullViewModel GetById(int id)
        {
            var response = this.PerformOperationAndHandleExceptions(() =>
            {
                return 
                    this.Data.Notes.All()
                    .Where(x => x.Id == id)
                    .Select(NoteFullViewModel.FromNote)
                    .FirstOrDefault();
            });

            return response;
        }

        [HttpPost]
        public HttpResponseMessage PostNote([FromBody] PostNoteViewModel model)
        {
            var response = this.PerformOperationAndHandleExceptions(() =>
            {

                var newNote = new Note()
                {
                    Author = model.Author,
                    Content = model.Content,
                    Latitude = model.Latitude,
                    Lontitude = model.Latitude,
                    PostAddress = model.PostAddress,
                    PostDate = DateTime.Now,
                    Title = model.Title,
                    DeviceId = model.DeviceId
                };

                this.Data.Notes.Add(newNote);
                this.Data.SaveChanges();

                return this.Request.CreateResponse(HttpStatusCode.Created);
            });

            return response;
        }
    }
}
