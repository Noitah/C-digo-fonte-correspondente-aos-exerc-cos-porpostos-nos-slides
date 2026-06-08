using Academico.Models;

namespace Academico.Data
{
    public static class AcademicoDbInitializer
    {
        public static void Initialize(AcademicoContext context)
        {
            context.Database.EnsureCreated();

            if (context.Instituicoes.Any())
            {
                return;
            }

            var instituicoes = new Instituicao[]
            {
                new Instituicao { Nome = "UFLA", Endereco = "Lavras - MG" },
                new Instituicao { Nome = "USP", Endereco = "São Paulo - SP" },
                new Instituicao { Nome = "UNICAMP", Endereco = "Campinas - SP" }
            };

            foreach (var i in instituicoes)
            {
                context.Instituicoes.Add(i);
            }
            context.SaveChanges();

            var departamentos = new Departamento[]
            {
                new Departamento { Nome = "Ciência da Computação", InstituicaoID = instituicoes[0].InstituicaoID },
                new Departamento { Nome = "Sistemas de Informação", InstituicaoID = instituicoes[0].InstituicaoID },
                new Departamento { Nome = "Engenharia de Software", InstituicaoID = instituicoes[1].InstituicaoID }
            };

            foreach (var d in departamentos)
            {
                context.Departamentos.Add(d);
            }
            context.SaveChanges();

            var cursos = new Curso[]
            {
                new Curso { Nome = "Programação Web", CargaHoraria = 60, DepartamentoID = departamentos[0].DepartamentoID },
                new Curso { Nome = "Banco de Dados", CargaHoraria = 80, DepartamentoID = departamentos[0].DepartamentoID },
                new Curso { Nome = "Inteligência Artificial", CargaHoraria = 72, DepartamentoID = departamentos[1].DepartamentoID }
            };

            foreach (var c in cursos)
            {
                context.Cursos.Add(c);
            }
            context.SaveChanges();
        }
    }
}
