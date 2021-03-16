namespace Application.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Application.Services.Contracts;
    using Application.Services.Messaging;
    using Application.Web.Infrastructure;
    using Application.Web.ViewModels.UserRelated.Posts;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    public class DashboardController : AdministrationController
    {
        private readonly IEmailSender emailSender;
        private readonly IViewRenderService viewRenderService;
        private readonly IPostsService postsService;
        private readonly IConfiguration configuration;

        public DashboardController(IEmailSender emailSender, IViewRenderService viewRenderService, IPostsService postsService, IConfiguration configuration)
        {
            this.emailSender = emailSender;
            this.viewRenderService = viewRenderService;
            this.postsService = postsService;
            this.configuration = configuration;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> EmailSender()
        {
            // gets the posts from last 7 days
            var viewModel = new AllLatestPostsViewModel()
            {
                Posts = this.postsService.GetAllLatestPosts(1, this.postsService.GetCount())
                .Where(x => x.CreatedOn.AddDays(7) >= DateTime.UtcNow).ToList(),
            };

            if (viewModel.Posts.Count == 0)
            {
                this.TempData["statusCode"] = "There are no posts in the last 7 days";
            }
            else
            {
                string viewPath = "~/Areas/Administration/Views/Dashboard/SendPostsToEmail.cshtml";
                string body = await this.viewRenderService.RenderToStringAsync(viewPath, viewModel);

                this.TempData["statusCode"] = await this.emailSender
                    .SendEmailAsync(this.configuration["Admin:Email"], "ASP.NET-App", this.configuration["SendGrid:ToEmail"], "Posts from the last 7 days", body);
            }

            return this.Redirect("/Administration/Posts");
        }
    }
}
