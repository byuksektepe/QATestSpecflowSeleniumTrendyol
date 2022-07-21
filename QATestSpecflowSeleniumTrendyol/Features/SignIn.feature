Feature: SignIn

Trendyol SignIn Feature File

@Smoke @SignInErrors
Scenario Outline: Visitor should be able see Sign-In form error messages
	Given Navigate to trendyol website
	And Click login button in navbar
	And Verify login page opened
	When Set email to "<Email>" and password to "<Password>" in signin form
	And Click login button to submit form
	Then Check exception message "<ExpectedMessage>" in signin form

Examples:
	| Description        | Email               | Password | ExpectedMessage                            |
	| Null email         |                     | pass123  | Lütfen geçerli bir e-posta adresi giriniz. |
	| Invalid email      | wthmail.lolx        | pass123  | Lütfen geçerli bir e-posta adresi giriniz. |
	| Null password      | berkant28@gmail.com |          | Lütfen şifrenizi giriniz.                  |
	| Unregistered email | berkant28@gmail.com | pass123  | E-posta adresiniz ve/veya şifreniz hatalı. |