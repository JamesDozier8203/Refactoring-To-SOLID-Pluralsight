﻿using MegaPricer.Data;

namespace MegaPricer.Services;

public class DefaultPriceCalculationStrategy : IPriceCalculationStrategy
{
  public void AddFeature(Feature feature, decimal userMarkup)
  {
    // do nothing
  }

  public void AddPart(Part part, decimal userMarkup)
  {
    // do nothing
  }

  public void AddWallTreatment(Part part, decimal userMarkup, float remainingWallHeight, float width)
  {
    // do nothing
  }

  public void Create(Kitchen kitchen)
  {
    // do nothing
  }
}
