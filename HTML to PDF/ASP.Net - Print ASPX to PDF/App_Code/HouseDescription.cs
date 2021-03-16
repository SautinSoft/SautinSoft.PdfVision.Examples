using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HouseDescription
/// </summary>
public class HouseDescription
{
	public HouseDescription()
	{
        HouseSpace = 120.0f;
        FloorsNumber = 2;
        IsBathroom = true;
        IsToilet = true;
        IsSwimmingPool = false;
	}
    public float HouseSpace { set; get; }
    public int FloorsNumber { set; get; }
    public bool IsBathroom { set; get; }
    public bool IsToilet { set; get; }
    public bool IsSwimmingPool { set; get; }
}