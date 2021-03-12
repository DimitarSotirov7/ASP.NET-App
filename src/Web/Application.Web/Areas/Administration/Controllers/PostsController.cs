namespace Application.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Application.Data;
    using Application.Data.Common.Repositories;
    using Application.Data.Models;
    using Application.Data.Models.Main;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    public class PostsController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Post> postsRepo;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepo;

        public PostsController(IDeletableEntityRepository<Post> postsRepo, IDeletableEntityRepository<ApplicationUser> usersRepo)
        {
            this.postsRepo = postsRepo;
            this.usersRepo = usersRepo;
        }

        // GET: Administration/Posts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = this.postsRepo.AllWithDeleted().Include(p => p.FromUser).Include(p => p.ToUser);
            return this.View(await applicationDbContext.ToListAsync());
        }

        // GET: Administration/Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var post = await this.postsRepo.All()
                .Include(p => p.FromUser)
                .Include(p => p.ToUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return this.NotFound();
            }

            return this.View(post);
        }

        // GET: Administration/Posts/Create
        public IActionResult Create()
        {
            this.ViewData["FromUserId"] = new SelectList(this.usersRepo.All(), "Id", "Id");
            this.ViewData["ToUserId"] = new SelectList(this.usersRepo.All(), "Id", "Id");
            return this.View();
        }

        // POST: Administration/Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Content,FromUserId,ToUserId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Post post)
        {
            if (this.ModelState.IsValid)
            {
                await this.postsRepo.AddAsync(post);
                await this.postsRepo.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["FromUserId"] = new SelectList(this.usersRepo.All(), "Id", "Id", post.FromUserId);
            this.ViewData["ToUserId"] = new SelectList(this.usersRepo.All(), "Id", "Id", post.ToUserId);
            return this.View(post);
        }

        // GET: Administration/Posts/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var post = this.postsRepo.All().FirstOrDefault(x => x.Id == id);
            if (post == null)
            {
                return this.NotFound();
            }

            this.ViewData["FromUserId"] = new SelectList(this.usersRepo.All(), "Id", "Id", post.FromUserId);
            this.ViewData["ToUserId"] = new SelectList(this.usersRepo.All(), "Id", "Id", post.ToUserId);
            return this.View(post);
        }

        // POST: Administration/Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Content,FromUserId,ToUserId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Post post)
        {
            if (id != post.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.postsRepo.Update(post);
                    await this.postsRepo.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.PostExists(post.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["FromUserId"] = new SelectList(this.usersRepo.All(), "Id", "Id", post.FromUserId);
            this.ViewData["ToUserId"] = new SelectList(this.usersRepo.All(), "Id", "Id", post.ToUserId);
            return this.View(post);
        }

        // GET: Administration/Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var post = await this.postsRepo.All()
                .Include(p => p.FromUser)
                .Include(p => p.ToUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return this.NotFound();
            }

            return this.View(post);
        }

        // POST: Administration/Posts/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = this.postsRepo.All().FirstOrDefault(x => x.Id == id);
            this.postsRepo.Delete(post);
            await this.postsRepo.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool PostExists(int id)
        {
            return this.postsRepo.All().Any(e => e.Id == id);
        }
    }
}
