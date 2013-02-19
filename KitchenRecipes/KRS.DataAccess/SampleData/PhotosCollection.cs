using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using KRS.Model.Infrastructure;
using KRS.Model.Photos;
using KRS.Model.RecipesParts;

namespace KRS.DataAccess.SampleData
{
    public class PhotosCollection
    {
        public static IQueryable<Photo> Photos()
        {
            var root = new DirectoryInfo(@"D:\GitHub\BaseRepository\KitchenRecipes\KRS.WebApi\Images");
            var recipesPhotos = new List<Photo>();
            WalkDirectoryTree(root, recipesPhotos);

            return recipesPhotos.AsQueryable();
        }

        static void WalkDirectoryTree(DirectoryInfo root, List<Photo> photos)
        {
            FileInfo[] files;
            DirectoryInfo[] subDirs;

            files = root.GetFiles("*.jpg");

            photos.AddRange(files.Select(image => image.Directory != null ? new Photo
                                                                                {
                                                                                    CreatedOn = DateTime.Now, 
                                                                                    ModifiedOn = DateTime.Now, 
                                                                                    Order = 1, 
                                                                                    PhotoPath = GetRelativePath(image.Directory.FullName, image.Name),
                                                                                } : null));

            subDirs = root.GetDirectories();
            foreach (DirectoryInfo dirInfo in subDirs)
            {
                WalkDirectoryTree(dirInfo, photos);
            }
        }

        public static string GetRelativePath(string fullpath, string name)
        {
            fullpath = fullpath.Replace(@"\", "/");
            int start = fullpath.IndexOf("/Images/", System.StringComparison.Ordinal);
            var result = "~"+fullpath.Substring(start, fullpath.Length - start);
            result += "/" + name;
            return result;
        }
    }
}