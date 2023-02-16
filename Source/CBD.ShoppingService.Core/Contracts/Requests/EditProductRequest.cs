﻿using System.ComponentModel.DataAnnotations;

namespace CBD.ShoppingService.Core.Contracts.Requests;

public record EditProductRequest {
	public string Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public string Price { get; set; }
	public string Quantity { get; set; }
}