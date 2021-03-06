package com.benjamin.camacho;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;

public class LoginPage {
	private final WebDriver driver;

	public LoginPage(WebDriver driver) {
		this.driver = driver;
		if (!"Facebook - Inicia sesi�n o reg�strate".equals(driver.getTitle())) {
			throw new IllegalStateException("This is not the login page");
		}
	}

	By usernameLocator = By.id("email");
	By passwordLocator = By.id("pass");
	By loginButtonLocator = By.id("u_0_8");
	
	public LoginPage typeUsername(String username) {
		driver.findElement(usernameLocator).sendKeys(username);
		return this;
	}

	public LoginPage typePassword(String password) {
		driver.findElement(passwordLocator).sendKeys(password);
		return this;
	}

	public HomePage submitLogin() {

		driver.findElement(loginButtonLocator).submit();
		return new HomePage(driver);
	}

	public LoginPage submitLoginExpectingFailure() {

		driver.findElement(loginButtonLocator).submit();

		return new LoginPage(driver);
	}

	public HomePage loginAs(String username, String password) {
		typeUsername(username);
		typePassword(password);
		return submitLogin();
	}
}
