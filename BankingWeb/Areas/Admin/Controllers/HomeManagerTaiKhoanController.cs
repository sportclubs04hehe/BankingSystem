using Banking.DataAccess.Repository.IRepository;
using Banking.Models;
using Banking.Models.ViewVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace BankingWeb.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class HomeManagerCardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeManagerCardController(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upsert(Guid? id)
        {
            CardVM cardVM = new()
            {
                Card = new(),
                AccountType = _unitOfWork.accountTypeRepository.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            if (id == null)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // lấy id của người dùng đang đăng nhập
                cardVM.Card.ApplicationUserId = userId;
                return View(cardVM);    
            }
            else
            {
                //update
                Card card = _unitOfWork.cardRepository.Get(p => p.Id == id && p.ApplicationUserId == User.FindFirstValue(ClaimTypes.NameIdentifier));
                if (card == null)
                {
                    return NotFound();
                }
                cardVM.Card = card;
                return View(cardVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(CardVM card)
        {
            if (ModelState.IsValid)
            {
                if (card.Card.Id == Guid.Empty)
                {
                    card.Card.ApplicationUserId = User.FindFirstValue(ClaimTypes.NameIdentifier); // gán id của người dùng đang đăng nhập vào trường ApplicationUserId
                    card.Card.DateOpen= DateTime.Now;
                    _unitOfWork.cardRepository.Add(card.Card);
                    _unitOfWork.Save();
                    TempData["success"] = "New record created successfully!";
                }
                else
                {
                    card.Card = _unitOfWork.cardRepository.Get(p => p.Id == card.Card.Id && p.ApplicationUserId == User.FindFirstValue(ClaimTypes.NameIdentifier));
                    if (card.Card == null)
                    {
                        return NotFound();
                    }
                    //existingCard.AccountNumber = card.Card.AccountNumber;
                    //existingCard.Balance = card.Card.Balance;
                    //existingCard.AccountTypeId = card.Card.AccountTypeId;
                    _unitOfWork.cardRepository.Update(card.Card);
                    _unitOfWork.Save();
                    TempData["success"] = "Update record successfully!";
                }
                return RedirectToAction("Index");
            }
            else
            {
                card.AccountType = _unitOfWork.accountTypeRepository.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                return View(card);
            }

        }



        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            IEnumerable<Card> cards = _unitOfWork.cardRepository.GetAll(includeProperties: "AccountType,ApplicationUser")
                .Where(t => t.ApplicationUserId == userId)
                .ToList();
            return Json(new { data = cards });
        }

        [HttpDelete]
        public IActionResult Lock(Guid? id)
        {
            //var cardDeleted = _unitOfWork.cardRepository.Get(p => p.Id == id);
            //if (cardDeleted == null)
            //{
            //    return Json(new { success = false, message = "Error while deleting!" });
            //}

            //_unitOfWork.cardRepository.Remove(cardDeleted);
            //_unitOfWork.Save();

            //return Json(new { success = true, message = "Delete Success!" });
            return View();

        }
        #endregion
    }
}
