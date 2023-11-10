Feature: Scenari
	Simple calculator for adding two numbers


Scenario: Recuperare la lista degli indirizzi
	Given il seguente utente 'agiacomini' e il seguente orario '2020-01-01'
	
	Given i seguenti indirizzi nella nostra base dati
	| Id | State | Country | ZipCode |
	| 1  | 'CA'  | 'USA'   | '90210' |
	| 2  | 'NY'  | 'USA'   | '10001' | 
	
	When chiedo la lista degli indirizzi
		
	Then ottengo i seguenti indirizzi nella risposta
	| Id | State | Country | ZipCode | CreatedBy  | UpdatedBy  | CreatedAt  | UpdatedAt  |
	| 1  | 'CA'  | 'USA'   | '90210' | agiacomini | agiacomini | 2020-01-01 | 2020-01-01 |
	| 2  | 'NY'  | 'USA'   | '10001' | agiacomini | agiacomini | 2020-01-01 | 2020-01-01 |