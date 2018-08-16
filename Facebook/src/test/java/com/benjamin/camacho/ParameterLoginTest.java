package com.benjamin.camacho;


import static org.junit.Assert.assertTrue;



import org.junit.AfterClass;
import org.junit.BeforeClass;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;

import junitparams.FileParameters;
import junitparams.JUnitParamsRunner;


@RunWith(JUnitParamsRunner.class)
public class ParameterLoginTest {
	private static WebDriver driver;
	@BeforeClass
	public static void setUpClass() {
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
    @FileParameters("./src/test/resources/data/data.csv")
    public void test(String user, String password) {
        
    	LoginPage login = new LoginPage(driver);
		HomePage home = login.loginAs(user, password);
		assertTrue(true);
    }
}