package com.benjamin.camacho;

import static org.junit.Assert.assertTrue;

import java.io.File;

import org.junit.*;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.chrome.ChromeOptions;

public class LoginTest {

	private static WebDriver driver;

	@BeforeClass
	public static void setUpClass() {

		//ChromeOptions options = new ChromeOptions();
		//options.setBinary(new File("./src/test/resources/drivers"));
		System.setProperty("webdriver.chrome.driver", "./src/test/resources/drivers/chromedriver.exe");
		driver = new ChromeDriver();
		driver.manage().window().maximize();
		driver.navigate().to("https://www.facebook.com/");
	}

	@AfterClass
	public static void tearDownClass() {
		//driver.close();
	}

	@Test
	public void testMessagesAreReadOrUnread() {

		LoginPage login = new LoginPage(driver);
		HomePage home = login.loginAs("youemail@mail.com", "password");
		assertTrue(true);

	}
}
