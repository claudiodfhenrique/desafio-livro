/****** Object:  View [dbo].[VW_APOLICE_SUSEP]    Script Date: 24/10/2024 19:28:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
 
CREATE VIEW [dbo].[VW_LIVROS_POR_AUTOR]
AS
SELECT 
	ROW_NUMBER() OVER(ORDER BY Autor.Nome) AS Id,
	L.Titulo,
	L.Editora,
	L.Edicao,
	A.Descricao AS 'Assunto',
	Autor.Nome AS 'AutorNome'
FROM Livro AS L
	LEFT JOIN LivroAssunto AS LA ON L.Cod = LA.Cod
	LEFT JOIN Assunto AS A ON LA.CodAss = A.CodAss
	LEFT JOIN LivroAutor AS LAutor ON L.Cod = LAutor.LivroCod
	LEFT JOIN Autor ON LAutor.AutorCodAu = Autor.CodAu
GROUP BY
	L.Titulo,
	L.Editora,
	L.Edicao,
	A.Descricao,
	Autor.Nome

GO