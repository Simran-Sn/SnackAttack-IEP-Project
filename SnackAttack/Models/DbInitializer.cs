using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SnackAttack.Models;

namespace SnackAttack.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            // Delete all existing data
            context.Database.ExecuteSqlRaw("DELETE FROM FavouriteRecipe");
            context.Database.ExecuteSqlRaw("DELETE FROM MealPlan");
            context.Database.ExecuteSqlRaw("DELETE FROM Review");
            context.Database.ExecuteSqlRaw("DELETE FROM Recipe");
            context.Database.ExecuteSqlRaw("DELETE FROM SnackAttackUser");

            // Add test users
            var user1 = new SnackAttackUser
            {
                FirstName = "Sarah",
                LastName = "Johnson",
                Email = "sarahj@example.com",
                IsPremium = true,
                Password = "Password1!"
            };
            context.SnackAttackUser.Add(user1);

            var user2 = new SnackAttackUser
            {
                FirstName = "Michael",
                LastName = "Lee",
                Email = "michaellee@example.com",
                IsPremium = false,
                Password = "Password2$"
            };
            context.SnackAttackUser.Add(user2);

            var user3 = new SnackAttackUser
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@example.com",
                IsPremium = true,
                Password = "Password3#"
            };
            context.SnackAttackUser.Add(user3);

            var user4 = new SnackAttackUser
            {
                FirstName = "Emily",
                LastName = "Wong",
                Email = "emilywong@example.com",
                IsPremium = false,
                Password = "Password4@"
            };
            context.SnackAttackUser.Add(user4);

            var user5 = new SnackAttackUser
            {
                FirstName = "Alex",
                LastName = "Davis",
                Email = "alexdavis@example.com",
                IsPremium = true,
                Password = "Password5#"
            };
            context.SnackAttackUser.Add(user5);

            // Add test recipes
            var recipe1 = new Recipe
            {
                Name = "Vegan Black Bean Chili",
                Description = "A hearty vegan chili made with black beans, vegetables, and spices.",
                Ingredients = "2 cans black beans, 1 onion, 1 bell pepper, 1 can diced tomatoes, 1 tbsp chili powder, 1 tsp cumin, salt and pepper to taste",
                Directions = "1. Saute onion and bell pepper in oil. 2. Add remaining ingredients and simmer for 20 minutes.",
                TotalEstimatedCost = 10.0m,
                Category = "Vegan"
            };
            context.Recipe.Add(recipe1);

            // Add test recipes continued
            var recipe2 = new Recipe
            {
                Name = "Vegetarian Lasagna",
                Description = "A classic lasagna recipe made with vegetables and cheese.",
                Ingredients = "1 box lasagna noodles, 1 jar marinara sauce, 1 container ricotta cheese, 1 bag spinach, 1 bag shredded mozzarella cheese",
                Directions = "1. Cook lasagna noodles according to package directions. 2. Mix together ricotta cheese and spinach. 3. Layer noodles, sauce, and cheese mixture in a baking dish. 4. Top with mozzarella cheese. 5. Bake at 375 degrees for 30-40 minutes.",
                TotalEstimatedCost = 20.0m,
                Category = "Vegetarian"
            };
            context.Recipe.Add(recipe2);

            var recipe3 = new Recipe
            {
                Name = "Grilled Salmon",
                Description = "A simple and delicious grilled salmon recipe.",
                Ingredients = "4 salmon fillets, 2 tbsp olive oil, 1 lemon, salt and pepper to taste",
                Directions = "1. Preheat grill to medium-high heat. 2. Brush salmon with olive oil and season with salt and pepper. 3. Grill salmon for 4-5 minutes per side, or until cooked through. 4. Squeeze lemon over salmon before serving.",
                TotalEstimatedCost = 25.0m,
                Category = "Pescatarian"
            };
            context.Recipe.Add(recipe3);

            var recipe4 = new Recipe
            {
                Name = "Pesto Pasta",
                Description = "A simple and flavorful pasta dish made with pesto sauce.",
                Ingredients = "1 box pasta, 1 jar pesto sauce, 1/2 cup grated Parmesan cheese, 1/4 cup pine nuts",
                Directions = "1. Cook pasta according to package directions. 2. Reserve 1/2 cup of pasta water. 3. Drain pasta and return to pot. 4. Add pesto sauce, Parmesan cheese, and pine nuts. 5. Toss to combine, adding reserved pasta water if necessary to thin the sauce.",
                TotalEstimatedCost = 15.0m,
                Category = "Vegetarian"
            };
            context.Recipe.Add(recipe4);

            var recipe5 = new Recipe
            {
                Name = "Chicken Enchiladas",
                Description = "A flavorful and easy-to-make chicken enchilada recipe.",
                Ingredients = "1 lb cooked shredded chicken, 1 can enchilada sauce, 8-10 corn tortillas, 2 cups shredded cheddar cheese",
                Directions = "1. Preheat oven to 375 degrees. 2. Pour a small amount of enchilada sauce into the bottom of a baking dish. 3. Dip each tortilla into the remaining enchilada sauce. 4. Fill each tortilla with shredded chicken and shredded cheese. 5. Roll up and place in the baking dish. 6. Cover with remaining enchilada sauce and shredded cheese. 7. Bake for 25-30 minutes, or until cheese is melted and bubbly.",
                TotalEstimatedCost = 18.0m,
                Category = "Omnivore"
            };
            context.Recipe.Add(recipe5);
            var recipe6 = new Recipe
            {
                Name = "Honey Mustard Salmon",
                Description = "A simple and delicious baked salmon recipe with honey mustard glaze.",
                Ingredients = "4 salmon fillets, 2 tbsp honey, 2 tbsp dijon mustard, 1 tbsp olive oil, salt and pepper to taste",
                Directions = "1. Preheat oven to 375 degrees. 2. Mix together honey, mustard, and olive oil. 3. Season salmon fillets with salt and pepper. 4. Brush honey mustard glaze over salmon. 5. Bake for 15-20 minutes.",
                TotalEstimatedCost = 25.0m,
                Category = "Pescatarian"
            };
            context.Recipe.Add(recipe6);

            var recipe7 = new Recipe
            {
                Name = "Beef Stir Fry",
                Description = "A quick and easy beef stir fry recipe with vegetables and soy sauce.",
                Ingredients = "1 lb beef, 1 onion, 2 bell peppers, 1 cup broccoli, 1 cup snap peas, 1/4 cup soy sauce, 1 tbsp cornstarch",
                Directions = "1. Slice beef into thin strips. 2. Saute beef and vegetables in oil. 3. Mix together soy sauce and cornstarch. 4. Add soy sauce mixture to pan and cook until thickened.",
                TotalEstimatedCost = 30.0m,
                Category = "Omnivore"
            };
            context.Recipe.Add(recipe7);

            var recipe8 = new Recipe
            {
                Name = "Caprese Salad",
                Description = "A classic Italian salad made with tomatoes, mozzarella, and basil.",
                Ingredients = "3-4 tomatoes, 1 ball fresh mozzarella cheese, fresh basil leaves, balsamic vinegar, olive oil, salt and pepper to taste",
                Directions = "1. Slice tomatoes and mozzarella cheese. 2. Layer tomatoes, cheese, and basil on a plate. 3. Drizzle with balsamic vinegar and olive oil. 4. Season with salt and pepper.",
                TotalEstimatedCost = 15.0m,
                Category = "Vegetarian"
            };
            context.Recipe.Add(recipe8);

            var recipe9 = new Recipe
            {
                Name = "Grilled Chicken Sandwich",
                Description = "A classic grilled chicken sandwich recipe with lettuce, tomato, and mayo.",
                Ingredients = "4 chicken breasts, 4 buns, lettuce, tomato, mayo",
                Directions = "1. Grill chicken breasts until cooked through. 2. Toast buns. 3. Assemble sandwiches with chicken, lettuce, tomato, and mayo.",
                TotalEstimatedCost = 20.0m,
                Category = "Omnivore"
            };
            context.Recipe.Add(recipe9);

            var recipe10 = new Recipe
            {
                Name = "Black Bean and Corn Salad",
                Description = "A refreshing and healthy salad made with black beans, corn, and vegetables.",
                Ingredients = "1 can black beans, 1 can corn, 1 red pepper, 1 green pepper, 1/4 cup chopped cilantro, 2 tbsp lime juice, 2 tbsp olive oil, salt and pepper to taste",
                Directions = "1. Rinse and drain black beans and corn. 2. Chop peppers and cilantro. 3. Mix together lime juice, olive oil, salt, and pepper. 4. Toss all ingredients together.",
                TotalEstimatedCost = 12.0m,
                Category = "Vegetarian"
            };
            context.Recipe.Add(recipe10);

            // Add test reviews
            var review1 = new Review
            {
                Rating = 5,
                Comment = "This chili was amazing! I loved how hearty and flavorful it was.",
                Recipe = recipe1,
                User = user1
            };
            context.Review.Add(review1);

            var review2 = new Review
            {
                Rating = 4,
                Comment = "I really enjoyed this vegetarian lasagna. The spinach and ricotta cheese mixture was delicious!",
                Recipe = recipe2,
                User = user2
            };
            context.Review.Add(review2);

            var review3 = new Review
            {
                Rating = 3,
                Comment = "The roasted vegetables in this dish were really good, but I felt like it was missing something.",
                Recipe = recipe3,
                User = user3
            };
            context.Review.Add(review3);

            var review4 = new Review
            {
                Rating = 5,
                Comment = "This lentil soup was the perfect comfort food for a chilly day. Will definitely make again!",
                Recipe = recipe4,
                User = user4
            };
            context.Review.Add(review4);

            var review5 = new Review
            {
                Rating = 4,
                Comment = "The stir fry sauce in this recipe was amazing. I added some extra veggies and it turned out great!",
                Recipe = recipe5,
                User = user5
            };
            context.Review.Add(review5);

            var review6 = new Review
            {
                Rating = 5,
                Comment = "These vegan pancakes were so fluffy and delicious. I will definitely be making them again!",
                Recipe = recipe6,
                User = user1
            };
            context.Review.Add(review6);

            var review7 = new Review
            {
                Rating = 3,
                Comment = "This beef was cooked perfectly, but I wasn't a fan of the cornstarch.",
                Recipe = recipe7,
                User = user2
            };
            context.Review.Add(review7);


            context.Review.Add(review7);

            var review8 = new Review
            {
                Rating = 4,
                Comment = "This quiche was really tasty and easy to make. I added some mushrooms for extra flavor.",
                Recipe = recipe8,
                User = user3
            };
            context.Review.Add(review8);

            var review9 = new Review
            {
                Rating = 5,
                Comment = "I loved this roasted vegetable salad. The balsamic dressing was the perfect complement to the veggies.",
                Recipe = recipe9,
                User = user4
            };
            context.Review.Add(review9);

            var review10 = new Review
            {
                Rating = 4,
                Comment = "The honey mustard sauce in this recipe was so good! I added some garlic for extra flavor.",
                Recipe = recipe10,
                User = user5
            };
            context.Review.Add(review10);

            var review11 = new Review
            {
                Recipe = recipe4,
                User = user3,
                Rating = 5,
                Comment = "This omnivore chicken alfredo is amazing! It's one of my favorite comfort foods."
            };
            context.Review.Add(review11);

            var review12 = new Review
            {
                Recipe = recipe4,
                User = user4,
                Rating = 3,
                Comment = "This omnivore chicken alfredo is pretty good, but I think it needs more seasoning."
            };
            context.Review.Add(review12);

            var review13 = new Review
            {
                Recipe = recipe9,
                User = user2,
                Rating = 4,
                Comment = "This was a delicious and healthy breakfast! Will definitely make it again."
            };
            context.Review.Add(review13);

            var review14 = new Review
            {
                Recipe = recipe9,
                User = user3,
                Rating = 5,
                Comment = "So easy to make and tasted great! Love the combination of flavors."
            };
            context.Review.Add(review14);

            var review15 = new Review
            {
                Recipe = recipe9,
                User = user5,
                Rating = 4,
                Comment = "This was a nice and refreshing breakfast option. Would make it again."
            };
            context.Review.Add(review15);

            // Add reviews for recipe10
            var review16 = new Review
            {
                Recipe = recipe10,
                User = user1,
                Rating = 5,
                Comment = "This is my new favorite dessert recipe! So rich and chocolaty."
            };
            context.Review.Add(review16);

            var review17 = new Review
            {
                Recipe = recipe10,
                User = user4,
                Rating = 4,
                Comment = "Yum! The sea salt adds the perfect touch to this sweet dessert."
            };
            context.Review.Add(review17);

            var review18 = new Review
            {
                Recipe = recipe10,
                User = user5,
                Rating = 5,
                Comment = "This was easy to make and tasted amazing! Will definitely make it again."
            };
            context.Review.Add(review18);

            var review19 = new Review
            {
                Rating = 4,
                Comment = "This beef was so tender!",
                Recipe = recipe7,
                User = user5
            };
            context.Review.Add(review19);

            var review20 = new Review
            {
                Rating = 3,
                Comment = "It was ok. Now a fan of vegetables",
                Recipe = recipe7,
                User = user3
            };
            context.Review.Add(review20);

            var review21 = new Review
            {
                Rating = 5,
                Comment = "This is was so easy to make and tasted amazing! Will definitely make it again",
                Recipe = recipe7,
                User = user1
            };
            context.Review.Add(review21);

            // Add test favorite recipes
            var favorite1 = new FavouriteRecipe
            {
                SnackAttackUser = user1,
                Recipe = recipe1
            };
            context.FavouriteRecipe.Add(favorite1);

            var favorite2 = new FavouriteRecipe
            {
                SnackAttackUser = user2,
                Recipe = recipe2
            };
            context.FavouriteRecipe.Add(favorite2);

            var favorite3 = new FavouriteRecipe
            {
                SnackAttackUser = user3,
                Recipe = recipe3
            };
            context.FavouriteRecipe.Add(favorite3);

            var favorite4 = new FavouriteRecipe
            {
                SnackAttackUser = user4,
                Recipe = recipe4
            };
            context.FavouriteRecipe.Add(favorite4);

            var favorite5 = new FavouriteRecipe
            {
                SnackAttackUser = user4,
                Recipe = recipe7
            };
            context.FavouriteRecipe.Add(favorite5);

            var favorite6 = new FavouriteRecipe
            {
                SnackAttackUser = user3,
                Recipe = recipe7
            };
            context.FavouriteRecipe.Add(favorite6);

            // Add recipes to user's meal plans
            var mealPlan1 = new MealPlan
            {
                User = user1,
                Recipe = recipe1,
                Date = DateTime.Today.AddDays(1)
            };
            context.MealPlan.Add(mealPlan1);

            var mealPlan2 = new MealPlan
            {
                User = user1,
                Recipe = recipe3,
                Date = DateTime.Today.AddDays(2)
            };
            context.MealPlan.Add(mealPlan2);

            var mealPlan3 = new MealPlan
            {
                User = user1,
                Recipe = recipe5,
                Date = DateTime.Today.AddDays(3)
            };
            context.MealPlan.Add(mealPlan3);

            var mealPlan4 = new MealPlan
            {
                User = user2,
                Recipe = recipe2,
                Date = DateTime.Today.AddDays(1)
            };
            context.MealPlan.Add(mealPlan4);

            var mealPlan5 = new MealPlan
            {
                User = user2,
                Recipe = recipe4,
                Date = DateTime.Today.AddDays(2)
            };
            context.MealPlan.Add(mealPlan5);

            var mealPlan6 = new MealPlan
            {
                User = user1,
                Recipe = recipe3,
                Date = DateTime.Today.AddDays(2)
            };
            context.MealPlan.Add(mealPlan6);

            var mealPlan7 = new MealPlan
            {
                User = user2,
                Recipe = recipe1,
                Date = DateTime.Today.AddDays(3)
            };
            context.MealPlan.Add(mealPlan7);

            var mealPlan8 = new MealPlan
            {
                User = user1,
                Recipe = recipe5,
                Date = DateTime.Today.AddDays(3)
            };
            context.MealPlan.Add(mealPlan8);

            var mealPlan9 = new MealPlan
            {
                User = user2,
                Recipe = recipe2,
                Date = DateTime.Today.AddDays(3)
            };
            context.MealPlan.Add(mealPlan9);

            var mealPlan10 = new MealPlan
            {
                User = user1,
                Recipe = recipe4,
                Date = DateTime.Today.AddDays(4)
            };
            context.MealPlan.Add(mealPlan10);

            var mealPlan11 = new MealPlan
            {
                User = user2,
                Recipe = recipe3,
                Date = DateTime.Today.AddDays(4)
            };
            context.MealPlan.Add(mealPlan11);

            var mealPlan12 = new MealPlan
            {
                User = user1,
                Recipe = recipe1,
                Date = DateTime.Today.AddDays(4)
            };
            context.MealPlan.Add(mealPlan12);

            var mealPlan13 = new MealPlan
            {
                User = user2,
                Recipe = recipe5,
                Date = DateTime.Today.AddDays(5)
            };
            context.MealPlan.Add(mealPlan13);

            var mealPlan14 = new MealPlan
            {
                User = user1,
                Recipe = recipe2,
                Date = DateTime.Today.AddDays(5)
            };
            context.MealPlan.Add(mealPlan14);

            var mealPlan15 = new MealPlan
            {
                User = user2,
                Recipe = recipe4,
                Date = DateTime.Today.AddDays(5)
            };
            context.MealPlan.Add(mealPlan15);

            var mealPlan16 = new MealPlan
            {
                User = user2,
                Recipe = recipe7,
                Date = DateTime.Today.AddDays(6)
            };
            context.MealPlan.Add(mealPlan16);

            var mealPlan17 = new MealPlan
            {
                User = user3,
                Recipe = recipe7,
                Date = DateTime.Today.AddDays(3)
            };
            context.MealPlan.Add(mealPlan17);

            var mealPlan18 = new MealPlan
            {
                User = user5,
                Recipe = recipe7,
                Date = DateTime.Today.AddDays(5)
            };
            context.MealPlan.Add(mealPlan18);

            context.SaveChanges();
        }
    }
}
