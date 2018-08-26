using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment1.Data;
using Assignment1.Models;
using System.Net.Http.Headers; 
using Microsoft.AspNetCore.Hosting; 
using Microsoft.AspNetCore.Http; 
using System.IO; 


namespace Assignment1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly QuantityBagsContext _context;
        private readonly IHostingEnvironment _hostingEnv;

        public ProductsController(QuantityBagsContext context, IHostingEnvironment hEnv)
        {
            _context = context;
            _hostingEnv = hEnv;
        }

        // GET: Products
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            ViewData["CurrentFilter"] = searchString;

            var products = from s in _context.Products select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.ProductDescription.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(s => s.ProductDescription);
                    break;

                default:
                    products = products.OrderBy(s => s.ProductDescription);
                    break;
            }
            return View(await products.AsNoTracking().ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.SingleOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["BrandID"] = new SelectList(_context.Brands, "BrandID", "BrandName");
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryDescription");
            ViewData["MaterialID"] = new SelectList(_context.Materials, "MaterialID", "MaterialDescription");
            ViewData["SizeID"] = new SelectList(_context.Sizes, "SizeID", "SizeDescription");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,ProductDescription,BrandID,CategoryID,MaterialID,SizeID,Price,SmallImage,MediumImage,LargeImage,TotalValue")] Product product, IList<IFormFile> _files)
        {
            var relativeName = "";
            var fileName = "";

            if (_files.Count < 1)
            {
                relativeName = "/Images/Default.jpg";
            }
            else
            {
                foreach (var file in _files)
                {
                    fileName = ContentDispositionHeaderValue
                                      .Parse(file.ContentDisposition)
                                      .FileName
                                      .Trim('"');
                    //Path for localhost
                    relativeName = "/Images/ProductImages/" + DateTime.Now.ToString("ddMMyyyy-HHmmssffffff") + fileName;

                    using (FileStream fs = System.IO.File.Create(_hostingEnv.WebRootPath + relativeName))
                    {
                        await file.CopyToAsync(fs);
                        fs.Flush();
                    }
                }
            }
            product.SmallImage = relativeName;
            try
            {





                if (ModelState.IsValid)
                {
                    _context.Add(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " + "Try again, and if the problem persists " + "see your system administrator.");
            }

            ViewData["BrandID"] = new SelectList(_context.Brands, "BrandID", "BrandName", product.BrandID);
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryDescription", product.CategoryID);
            ViewData["MaterialID"] = new SelectList(_context.Materials, "MaterialID", "MaterialDescription", product.MaterialID);
            ViewData["SizeID"] = new SelectList(_context.Sizes, "SizeID", "SizeDescription", product.SizeID);
            return View(product);
            }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.SingleOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["BrandID"] = new SelectList(_context.Brands, "BrandID", "BrandName", product.BrandID);
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryDescription", product.CategoryID);
            ViewData["MaterialID"] = new SelectList(_context.Materials, "MaterialID", "MaterialDescription", product.MaterialID);
            ViewData["SizeID"] = new SelectList(_context.Sizes, "SizeID", "SizeDescription", product.SizeID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,BrandID,CategoryID,LargeImage,MaterialID,MediumImage,Price,ProductDescription,SizeID,SmallImage,TotalValue")] Product product, IList<IFormFile> _files)
        {
            var relativeName = "";
            var fileName = "";

            if (_files.Count < 1)
            {
                relativeName = "/Images/Default.jpg";
            }
            else
            {
                foreach (var file in _files)
                {
                    fileName = ContentDispositionHeaderValue
                                      .Parse(file.ContentDisposition)
                                      .FileName
                                      .Trim('"');
                    //Path for localhost
                    relativeName = "/Images/ProductImages/" + DateTime.Now.ToString("ddMMyyyy-HHmmssffffff") + fileName;

                    using (FileStream fs = System.IO.File.Create(_hostingEnv.WebRootPath + relativeName))
                    {
                        await file.CopyToAsync(fs);
                        fs.Flush();
                    }
                }
            }
            product.SmallImage = relativeName;
            try
            {

                if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }

            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " + "Try again, and if the problem persists " + "see your system administrator.");
            }
            ViewData["BrandID"] = new SelectList(_context.Brands, "BrandID", "BrandName", product.BrandID);
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryDescription", product.CategoryID);
            ViewData["MaterialID"] = new SelectList(_context.Materials, "MaterialID", "MaterialDescription", product.MaterialID);
            ViewData["SizeID"] = new SelectList(_context.Sizes, "SizeID", "SizeDescription", product.SizeID);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.SingleOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(m => m.ProductID == id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductID == id);
        }
    }
}
