Feature: SignUp

Trendyol SignUp Feature File

@Smoke @SignUpErrors
Scenario Outline: Visitor should be able see Sign-Up form error messages
	Given Navigate to trendyol website
	And Click signup button in navbar
	And Verify signup page opened
	When Set email to "<Email>" and password to "<Password>" in signup form
	And Click signup button to submit form
	And Check password warner if required to "<PasswordWarnerMessage>"
	Then Check exception message "<ExpectedMessage>" in signup form

Examples:
	| Description                  | Email               | Password        | ExpectedMessage                                | PasswordWarnerMessage |
	| Null email                   |                     | WhatTheHell!Is4 | E-posta ve şifrenizi giriniz.                  | Güçlü Şifre           |
	| Invalid email                | wthmail.lolx        | WhatTheHell!Is4 | Lütfen geçerli bir email adresi giriniz.       | Güçlü Şifre           |
	| Null password                | berkant28@gmail.com |                 | E-posta ve şifrenizi giriniz.                  |                       |
	| 7 < letter pass              | berkant28@gmail.com | some            | Şifreniz 7 ile 15 karakter arasında olmalıdır. | Zayıf Şifre           |
	| 7 > letter pass              | berkant28@gmail.com | somepass        | Şifreniz en az 1 rakam içermelidir.            | Zayıf Şifre           |
	| 7 > letter with numbers pass | berkant28@gmail.com | somepass2       |                                                | Zayıf Şifre           |
	| Medium password              | berkant28@gmail.com | somepass2A      |                                                | Orta Şifre            |
