use pubs;
GO

DROP VIEW I;
DROP VIEW II;
DROP VIEW III;
DROP VIEW IV;

GO
-- a)

CREATE VIEW I AS
			SELECT title,au_fname FROM
			(titles JOIN titleauthor ON titles.title_id=titleauthor.title_id) JOIN authors ON titleauthor.au_id=authors.au_id;

GO
CREATE VIEW II AS
			SELECT pub_name,fname FROM
			(publishers JOIN employee ON publishers.pub_id=employee.pub_id);

GO
CREATE VIEW III AS
			SELECT title,stor_name 
			FROM (((publishers JOIN titles ON publishers.pub_id = titles.pub_id) JOIN sales ON titles.title_id=sales.title_id)) JOIN stores ON sales.stor_id=stores.stor_id;

GO
CREATE VIEW IV AS
			SELECT distinct pub_name,type FROM (publishers JOIN titles ON publishers.pub_id = titles.pub_id) ;
		
	
-- b)
GO	
/*SELECT title,au_fname FROM I;

SELECT pub_name,fname FROM II;

SELECT title,stor_name FROM III;

SELECT pub_name FROM IV WHERE type='business';
GO
*/
-- c)

/*ALTER VIEW I AS
			SELECT au_fname,stores.stor_name FROM
			((titles JOIN titleauthor ON titles.title_id=titleauthor.title_id) JOIN authors ON titleauthor.au_id=authors.au_id) JOIN (sales JOIN stores ON sales.stor_id=stores.stor_id) ON sales.title_id=titles.title_id;


insert into BusinessBooks (title_id, title, type, pub_id, price, notes)
values ('BDTst1','New BD Book','popular_comp','1389',$30.00,'A must Read for DB Course');

-- Nao faz sentido pois para uma view ser updatable tem que incluir uma só tabela vase na sua definição e os seguintos atribuitos_ primary key e todos os NOT NULL sem default value,
-- e tambem nao e updatable se utilizar varias tabelas base (joins) ou utilizar agrupamentos de atributos, algo que nao cumprimos nesta view
-- Por acaso funcionou, ja da segunda vez nao podemo repetir a primary key pelo que dá Violation of PRIMARY KEY constraint 'UPKCL_titleidind'. Cannot insert duplicate key in object 'dbo.titles'. The duplicate key value is (BDTst1).

SELECT *
FROM BusinessBooks

ALTER VIEW BusinessBooks AS
					SELECT *
					FROM titles
					WHERE type='Business'
					WITH check option;

*/