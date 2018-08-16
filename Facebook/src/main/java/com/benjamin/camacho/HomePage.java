package com.benjamin.camacho;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;

public class HomePage {

	private final WebDriver driver;

	public HomePage(WebDriver driver) {
		this.driver = driver;
	}

	By usernameLocator = By.id("js_8");
	By passwordLocator = By.id("pass");
	By loginButtonLocator = By.id("u_0_2");

}
