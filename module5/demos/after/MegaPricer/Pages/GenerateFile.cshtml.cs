﻿using MegaPricer.Data;
using MegaPricer.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MegaPricer.Pages;

public class GenerateFileModel : PageModel
{
  private readonly ILogger<GenerateFileModel> _logger;
  private readonly IPricingService _pricingService;
  private readonly PriceReportCalculationStrategy _priceCalculationStrategy;

  public GenerateFileModel(ILogger<GenerateFileModel> logger,
    IPricingService pricingService,
    PriceReportCalculationStrategy priceReportCalculationStrategy)
  {
    _logger = logger;
    _pricingService = pricingService;
    _priceCalculationStrategy = priceReportCalculationStrategy;
  }

  public void OnGet()
  {
    if (!(User is null) && User.Identity.IsAuthenticated)
    {
      if (!Context.Session.ContainsKey(User.Identity.Name))
      {
        Context.Session.Add(User.Identity.Name, new Dictionary<string, object>());
      }
      if (!Context.Session[User.Identity.Name].ContainsKey("CompanyShortName"))
      {
        Context.Session[User.Identity.Name].Add("CompanyShortName", "Acme");
      }
      if (!Context.Session[User.Identity.Name].ContainsKey("PricingOff"))
      {
        Context.Session[User.Identity.Name].Add("PricingOff", "N");
      }
    }

    string userName = User.Identity.Name;
    PriceRequest priceRequest = new()
    {
      kitchenId = 1,
      wallOrderNum = 1,
      userName = userName
    };
    _pricingService.CalculatePrice(priceRequest, _priceCalculationStrategy);
  }
}
