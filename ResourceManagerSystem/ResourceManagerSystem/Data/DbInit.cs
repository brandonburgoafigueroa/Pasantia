using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ResourceManagerSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManagerSystem.Data
{
    public static class DbInit
    {

        internal static void Seed(ApplicationDbContext context)
        {
            if (!context.Color.Any())
            {
                List<Color> Colors=new List<Color>() {
                    new Color(){ ColorName="Sin Color"},
                    new Color(){ ColorName="Verde"},
                    new Color(){ ColorName="Blanco"},
                    new Color(){ ColorName="Rojo"},
                    new Color(){ ColorName="Negro"},
                    new Color(){ ColorName="Plomo"},
                    new Color(){ ColorName="Cafe"},
                };
                foreach (var item in Colors)
                {
                    context.Color.Add(item);
                }
                
            }
            if (!context.Size.Any())
            {
                List<Size> Sizes = new List<Size>()
                {
                    new Size(){SizeName="Sin talla" },
                    new Size(){SizeName="XS" },
                    new Size(){SizeName="S" },
                    new Size(){SizeName="M" },
                    new Size(){SizeName="L" },
                    new Size(){SizeName="XL" },
                    new Size(){SizeName="XXL" },
                    new Size(){SizeName="35" },
                    new Size(){SizeName="36" },
                    new Size(){SizeName="37" },
                    new Size(){SizeName="38" },
                    new Size(){SizeName="39" },
                    new Size(){SizeName="40" },
                };
                foreach (var item in Sizes)
                {
                    context.Size.Add(item);
                }

                context.SaveChanges();
        }
    }
    }
}
