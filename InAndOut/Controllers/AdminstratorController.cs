
using InAndOut.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminstratorController : Controller
    {
        private  RoleManager<IdentityRole> RoleManager { get; }
        private readonly UserManager<IdentityUser> _userManager;

        public AdminstratorController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            RoleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };
                var result  = await RoleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
           
            return View(model);

        }
        [HttpGet]
        public async Task<IActionResult> AddOrRemoveAdmin()
        {
            var identityRoleAdmin = new IdentityRole
            {
                Name = "Admin"
            };
            var identityRoleUser = new IdentityRole
            {
                Name = "User"
            };
            var model = new List<UserRoleViewModel>();
            foreach(var user in _userManager.Users)
            {
                if (user.Email.ToUpper().Equals("admin@movieEzy.com".ToUpper()))
                    continue;

                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    
                    
                };
                if(await _userManager.IsInRoleAsync(user, identityRoleAdmin.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;

                }
                model.Add(userRoleViewModel);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrRemoveAdmin(List<UserRoleViewModel> users)
        {
            var identityRoleAdmin = new IdentityRole
            {
                Name = "Admin"
            };
            var identityRoleUser = new IdentityRole
            {
                Name = "User"
            };
            if (ModelState.IsValid)
            {
                for (var i = 0;i<users.Count; i++ )
            {
                    var user = await _userManager.FindByIdAsync(users[i].UserId);
                    IdentityResult result = null;
                    if (users[i].IsSelected && !(await _userManager.IsInRoleAsync(user, identityRoleAdmin.Name)))
                    {
                        result = await _userManager.AddToRoleAsync(user, identityRoleAdmin.Name);
                        result = await _userManager.RemoveFromRoleAsync(user, identityRoleUser.Name);

                    }
                    else if(!users[i].IsSelected && (await _userManager.IsInRoleAsync(user, identityRoleAdmin.Name)))
                    {

                        result = await _userManager.RemoveFromRoleAsync(user, identityRoleAdmin.Name);
                        result = await _userManager.AddToRoleAsync(user, identityRoleUser.Name);

                    }
                    else
                    {
                        continue;
                    }
               
                }
            }
            
            return View(users);
        }

        [HttpGet]
        public IActionResult RemoveUsers()
        {
            var identityRoleAdmin = new IdentityRole
            {
                Name = "Admin"
            };
            var identityRoleUser = new IdentityRole
            {
                Name = "User"
            };
            var model = new List<UserRoleViewModel>();
            foreach (var user in _userManager.Users)
            {
                if (user.Email.ToUpper().Equals("admin@movieEzy.com".ToUpper()))
                    continue;

                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                };
              
                model.Add(userRoleViewModel);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveUsers(List<UserRoleViewModel> users)
        {
            var identityRoleAdmin = new IdentityRole
            {
                Name = "Admin"
            };
            var identityRoleUser = new IdentityRole
            {
                Name = "User"
            };
            if (ModelState.IsValid)
            {
                for (var i = 0; i < users.Count; i++)
                {
                    var user = await _userManager.FindByIdAsync(users[i].UserId);
                    IdentityResult result = null;

                    if (users[i].IsSelected )
                    {
                        result = await _userManager.RemoveFromRoleAsync(user, identityRoleUser.Name);

                            result = await _userManager.RemoveFromRoleAsync(user, identityRoleAdmin.Name);

                                result = await _userManager.DeleteAsync(user);
                                if (result.Succeeded)
                                {
                                    return RedirectToAction("RemoveUsers","Adminstrator");

                                }
                            
                        
                        
                        
                    }
                    else
                    {
                        continue;
                    }

                }
            }

            return View(users);
        }

    }
}
