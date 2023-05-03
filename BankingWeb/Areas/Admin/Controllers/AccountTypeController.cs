using Banking.DataAccess.Repository.IRepository;
using Banking.Models;
using Banking.UAUI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BankingWeb.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = SD.Role_Admin)]
    public class AccountTypeController : Controller
    {
            private readonly IUnitOfWork _unitOfWork;
            public AccountTypeController(IUnitOfWork unit)
            {
                _unitOfWork = unit;
            }
            public IActionResult Index()
            {
                IEnumerable<AccountType> accountTypes = _unitOfWork.accountTypeRepository.GetAll();

                return View(accountTypes);
            }
            public IActionResult Upsert(int? id)
            {

                if (id == 0 || id == null)
                {
                    //create
                    return View(new AccountType());
                }
                else
                {
                    //update
                    AccountType accountType = _unitOfWork.accountTypeRepository.Get(p => p.Id == id);
                    return View(accountType);
                }
            }

            [HttpPost]
            public IActionResult Upsert(AccountType accountType)
            {
                if (ModelState.IsValid)
                {

                    if (accountType.Id == 0)
                    {
                        _unitOfWork.accountTypeRepository.Add(accountType);
                        _unitOfWork.Save();
                        TempData["success"] = "New record created successfully!";
                    }
                    else
                    {
                        _unitOfWork.accountTypeRepository.Update(accountType);
                        _unitOfWork.Save();
                        TempData["success"] = "Update record successfully!";
                    }

                    return RedirectToAction("Index");
                }
                else
                {

                    return View(accountType);
                }


            }



            #region API CALLS
            [HttpGet]
            public IActionResult GetAll()
            {
                IEnumerable<AccountType> accountTypes = _unitOfWork.accountTypeRepository.GetAll();
                return Json(new { data = accountTypes });

            }

            [HttpDelete]
            public IActionResult Delete(int? id)
            {
                var accountTypeDeleted = _unitOfWork.accountTypeRepository.Get(p => p.Id == id);
                if (accountTypeDeleted == null)
                {
                    return Json(new { success = false, message = "Error while deleting!" });
                }

                _unitOfWork.accountTypeRepository.Remove(accountTypeDeleted);
                _unitOfWork.Save();

                return Json(new { success = true, message = "Delete Success!" });

            }
            #endregion
        } 
}
