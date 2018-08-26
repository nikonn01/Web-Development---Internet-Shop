using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1.Models;

namespace Assignment1.Data
{
    public class DbInitializer
    {
        public static void Initialize(QuantityBagsContext context)
        {
            context.Database.EnsureCreated();

            
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var products = new Product[]
            {
            
            
            };
            foreach (Product s in products)
            {
                context.Products.Add(s);
            }
            context.SaveChanges();

            var brands = new Brand[]
            {
            
            };
            foreach (Brand c in brands)
            {
                context.Brands.Add(c);
            }
            context.SaveChanges();

            var categories = new Category[]
            {

            };
            foreach (Category a in categories)
            {
                context.Categories.Add(a);
            }
            context.SaveChanges();

            var colours = new Colour[]
           {

           };
            foreach (Colour b in colours)
            {
                context.Colours.Add(b);
            }
            context.SaveChanges();

            var colourallocations = new ColourAllocation[]
           {

           };
            foreach (ColourAllocation d in colourallocations)
            {
                context.ColourAllocations.Add(d);
            }
            context.SaveChanges();

            var materials = new Material[]
           {

           };
            foreach (Material e in materials)
            {
                context.Materials.Add(e);
            }
            context.SaveChanges();

            var orders = new Order[]
          {

          };
            foreach (Order f in orders)
            {
                context.Orders.Add(f);
            }
            context.SaveChanges();

            var sizes = new Size[]
          {

          };
            foreach (Size g in sizes)
            {
                context.Sizes.Add(g);
            }
            context.SaveChanges();


            var users = new User[]
          {

          };
            foreach (User h in users)
            {
                context.Users.Add(h);
            }
            context.SaveChanges();


        }
    }
}
