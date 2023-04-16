using System;

namespace Chayhana.Service.Exeptions;

public class CustomExeption : Exception
{
    public int Code { get; set; }
	public CustomExeption(int code = 500, string message = "Something went wrong") : base(message)
	{
		this.Code = code;
	}
}
