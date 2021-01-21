using EI20_21_ESII_PI_GGLP.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EI20_21_ESII_PI_GGLP.Models
{
    public class SeedData
    {

        internal static void Populate(GGLPDbContext dbContext)
        {
            PopulateEstado(dbContext);
            PopulateCategoria(dbContext);
            PopulateDia(dbContext);
            PopulatePontoDeInteresse(dbContext);
        }


        private static void PopulateEstado(GGLPDbContext dbContext)
        {
            if (dbContext.Estado.Any())
            {
                return;
            }

            dbContext.Estado.AddRange(
                new Estado
                {
                    ENome = "Disponível",
                    EComments = "O Ponto De Interesse encontrasse disponível para receber visitas."
                },
                new Estado
                {
                    ENome = "Indisponível",
                    EComments = "O Ponto De Interesse não se encontra disponível para receber visitas."
                },
                new Estado
                {
                    ENome = "Quarentena",
                    EComments = "O Ponto De Interesse encontrasse em quarentena devia a uma situação pandemica."
                }
            );

            dbContext.SaveChanges();
        }

        

        private static void PopulateCategoria(GGLPDbContext dbContext)
        {
            if (dbContext.Categoria.Any())
            {
                return;
            }

            dbContext.Categoria.AddRange(
                new Categoria
                {
                    CTipo = "Monumento",
                    CComments = "Estrutura ou edifício arquitectónico com história local."
                },
                new Categoria
                {
                    CTipo = "Museu",
                    CComments = "Local com exposições de objecto e cultura local."
                },
                new Categoria
                {
                    CTipo = "Restauração",
                    CComments = "Local com a oportunidade de apreciar diversos pratos locais."
                },
                new Categoria
                {
                    CTipo = "Shopping",
                    CComments = "Loja ou local com diversas lojas de diversas dos mais variados tipos."
                },
                new Categoria
                {
                    CTipo = "Espaço Aberto",
                    CComments = "Local ao ar livre com diversas actividades de lazer."
                },
                new Categoria
                {
                    CTipo = "Teatro",
                    CComments = "Local com diversas actividades de entretendimento e lazer."
                },
                new Categoria
                {
                    CTipo = "Hotel",
                    CComments = "Estabelecimento que provê alojamento e, habitualmente, refeições, entretenimentos e outros serviços para o público."
                },
                new Categoria
                {
                    CTipo = "Hipermercado",
                    CComments = "Grande estabelecimento comercial em regime de autosserviço, que oferece uma vasta gama de produtos alimentares, eletrodomésticos, vestuário e outros."
                },
                new Categoria
                {
                    CTipo = "Farmácia",
                    CComments = "Estabelecimento comercial de atendimento ao público onde se vendem medicamentos, substâncias para uso terapêutico, cosméticos, produtos de higiene, etc..."
                },
                new Categoria
                {
                    CTipo = "Cafetaria / Bar",
                    CComments = "Estabelecimento onde se serve café, outras bebidas, e algumas comidas leves. / Estabelecimento noturno onde se servem bebidas, sobretudo alcoólicas, e se ouve música."
                },
                new Categoria
                {
                    CTipo = "Mercado",
                    CComments = "Lugar público onde se compram mercadorias postas à venda, feira."
                },
                new Categoria
                {
                    CTipo = "MiniMercado",
                    CComments = "Pequeno estabelecimento comercial em regime de autosserviço, que oferece uma vasta gama de produtos alimentares, eletrodomésticos, vestuário e outros."
                },
                new Categoria
                {
                    CTipo = "Hostel",
                    CComments = "Estabelecimento que fornece serviços de alojamento, em quartos privados ou coletivos (dormitórios) a preços inferiores aos de um hotel; albergue."
                },
                new Categoria
                {
                    CTipo = "Banco",
                    CComments = "Instituição bancária, normalmente pública, que em geral é responsável pela emissão de moeda, pela fiscalização das instituições e da atividade financeira de um país, pelo controlo do crédito, pela fixação das taxas de juro e pela divulgação de análises e resultados económicos."
                }
            );

            dbContext.SaveChanges();
        }


        private static void PopulateDia(GGLPDbContext dbContext)
        {
            if (dbContext.Dia.Any())
            {
                return;
            }

            dbContext.Dia.AddRange(
                new Dia
                {
                    DNome = "Útil",
                    DComments = "Segunda, Terça, Quarta, Quinta, Sexta."
                },
                new Dia
                {
                    DNome = "Fim de Semana",
                    DComments = "Sábado, Domingo."
                },
                new Dia
                {
                    DNome = "Feriado",
                    DComments = "Dia histórico e/ou festivo, com significado nacional ou local."
                }
            );

            dbContext.SaveChanges();
        }



        private static void PopulatePontoDeInteresse(GGLPDbContext dbContext)
        {
            if (dbContext.PontoDeInteresse.Any())
            {
                return;
            }

            dbContext.PontoDeInteresse.AddRange(
                new PontoDeInteresse
                {
                    //PontoDeInteresseID
                    CategoriaID = 3,
                    PImagem = ReadFile("wwwroot/assets/img/1.jpg"),
                    PNome = "Sé da Guarda",
                    PDescricao = "A Catedral da Guarda é uma igreja católica localizada na cidade da Guarda, no nordeste de Portugal.A sua construção decorreu de 1390 até meados do século XVI, combinando os estilos arquitetónico Gótico e Manuelino.",
                    PEndereco = "Praça Luís de Camoes, 6300-714, Guarda",
                    PCoordenadas = "https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d12128.537572679055!2d-7.2698275!3d40.5386199!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x29345b6fc74d0998!2sS%C3%A9%20da%20Guarda!5e0!3m2!1sen!2spt!4v1610968706114!5m2!1sen!2spt",
                    PContacto = 969330910,
                    PEmail = "geral@freguesiadaguarda.pt",
                    PNumPessoas = 0,
                    PMaxPessoas = 20,
                    EstadoID = 1,
                    PDataEstado = DateTime.Today,
                    PComments = "Local histórico com possibilidade de assistir a missas e eventos religiosos."
                },
                new PontoDeInteresse
                {
                    //PontoDeInteresseID
                    CategoriaID = 4,
                    PImagem = ReadFile("wwwroot/assets/img/2.jpg"),
                    PNome = "La Vie Guarda",
                    PDescricao = "O novo LA VIE Guarda Shopping Center é uma nova página na vida da cidade. É um ponto de encontro entre pessoas, ideias, amigos, família, moda e tradição.",
                    PEndereco = "Av. Bombeiros Vol. Egitanienses nº5 loja 3.50, 6300-523, Guarda",
                    PCoordenadas = "https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d12128.204160948635!2d-7.2663882!3d40.5404615!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x22d46a43da7ab0ad!2sNorte%20Moda!5e0!3m2!1sen!2spt!4v1610968639313!5m2!1sen!2spt",
                    PContacto = 271210732,
                    PEmail = "guarda@lavieshopping.pt",
                    PNumPessoas = 0,
                    PMaxPessoas = 150,
                    EstadoID = 1,
                    PDataEstado = DateTime.Today,
                    PComments = "Espaço com diversas e vários tipos de lojas. Espaço de restauração, lazer, etc..."
                },
                new PontoDeInteresse
                {
                    //PontoDeInteresseID
                    CategoriaID = 3,
                    PImagem = ReadFile("wwwroot/assets/img/3.jpg"),
                    PNome = "Igreja da Misericórdia",
                    PDescricao = "Embora modesta, é a obra barroca mais importante da cidade, com as formas e o trabalho da pedra acentuados pelo contraste do granito com o branco das paredes caiadas.",
                    PEndereco = "Lgo João de Almeida 5, 6300-772, Guarda",
                    PCoordenadas = "https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d12128.588915813494!2d-7.2673809!3d40.5383363!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x631a765021039a6e!2sIgreja%20da%20Miseric%C3%B3rdia!5e0!3m2!1sen!2spt!4v1610968563132!5m2!1sen!2spt",
                    PContacto = 969330910,
                    PEmail = "geral@freguesiadaguarda.pt",
                    PNumPessoas = 0,
                    PMaxPessoas = 30,
                    EstadoID = 1,
                    PDataEstado = DateTime.Today,
                    PComments = "No interior, de nave única, salientam-se os altares em estilo barroco, principalmente o da capela-mor de grandes dimensões."
                },
                new PontoDeInteresse
                {
                    //PontoDeInteresseID
                    CategoriaID = 6,
                    PImagem = ReadFile("wwwroot/assets/img/5.jpg"),
                    PNome = "Teatro Municipal",
                    PDescricao = "Espaço de divulgação e promoção dos eventos culturais organizados, programados ou apoiados pelo Teatro Municipal da Guarda.",
                    PEndereco = "R. Batalha Reis 12, 6300-668, Guarda",
                    PCoordenadas = "https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d12128.537572679055!2d-7.2698275!3d40.5386199!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x29345b6fc74d0998!2sS%C3%A9%20da%20Guarda!5e0!3m2!1sen!2spt!4v1610848692106!5m2!1sen!2spt",
                    PContacto = 271205240,
                    PEmail = "geral@tmg.com.pt",
                    PNumPessoas = 0,
                    PMaxPessoas = 100,
                    EstadoID = 1,
                    PDataEstado = DateTime.Today,
                    PComments = "Espaço com diversas e vários tipos de actividades de lazer, como exibição de cultura, teatro, cinematografia, etc..."
                }



                //


                //new PontoDeInteresse
                //{
                //    //PontoDeInteresseID
                //    CategoriaID = 8,
                //    PImagem = ReadFile("wwwroot/assets/img/5.jpg"),
                //    PNome = "Modelo Continente",
                //    PDescricao = "O hipermercado onde encontra todas as promoções, campanhas e produtos aos preços mais baixos.",
                //    PEndereco = "Freguesia S. Vicente, R. do Ferrinho, 6300-566, Guarda",
                //    PCoordenadas = "https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d12127.231499683416!2d-7.2647305!3d40.5458336!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x42f27027838f233e!2sContinente%20Modelo%20Guarda!5e0!3m2!1sen!2spt!4v1611138323924!5m2!1sen!2spt",
                //    PContacto = 271100530,
                //    PEmail = "",
                //    PNumPessoas = ,
                //    PMaxPessoas = 60,
                //    EstadoID = 1,
                //    PDataEstado = DateTime.Today,
                //    PComments = "Com piso em carpete e móveis de madeira, os quartos e suítes modestos oferecem Wi - Fi gratuito, TV por satélite e frigobar, bem como cofre. O buffet de café da manhã é cortesia.Outras comodidades incluem um restaurante despretensioso, espaço para reuniões e um bar com lareira.Estacionamento disponível."
                //},
                //new PontoDeInteresse
                //{
                //    //PontoDeInteresseID
                //    CategoriaID = 6,
                //    PImagem = ReadFile("wwwroot/assets/img/5.jpg"),
                //    PNome = "Teatro Municipal",
                //    PDescricao = "Espaço de divulgação e promoção dos eventos culturais organizados, programados ou apoiados pelo Teatro Municipal da Guarda.",
                //    PEndereco = "R. Batalha Reis 12, 6300-668, Guarda",
                //    PCoordenadas = "https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d12128.537572679055!2d-7.2698275!3d40.5386199!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x29345b6fc74d0998!2sS%C3%A9%20da%20Guarda!5e0!3m2!1sen!2spt!4v1610848692106!5m2!1sen!2spt",
                //    PContacto = 271205240,
                //    PEmail = "geral@tmg.com.pt",
                //    PNumPessoas = 0,
                //    PMaxPessoas = 100,
                //    EstadoID = 1,
                //    PDataEstado = DateTime.Today,
                //    PComments = "Espaço com diversas e vários tipos de actividades de lazer, como exibição de cultura, teatro, cinematografia, etc..."
                //},
                //new PontoDeInteresse
                //{
                //    //PontoDeInteresseID
                //    CategoriaID = 6,
                //    PImagem = ReadFile("wwwroot/assets/img/5.jpg"),
                //    PNome = "Teatro Municipal",
                //    PDescricao = "Espaço de divulgação e promoção dos eventos culturais organizados, programados ou apoiados pelo Teatro Municipal da Guarda.",
                //    PEndereco = "R. Batalha Reis 12, 6300-668, Guarda",
                //    PCoordenadas = "https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d12128.537572679055!2d-7.2698275!3d40.5386199!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x29345b6fc74d0998!2sS%C3%A9%20da%20Guarda!5e0!3m2!1sen!2spt!4v1610848692106!5m2!1sen!2spt",
                //    PContacto = 271205240,
                //    PEmail = "geral@tmg.com.pt",
                //    PNumPessoas = 0,
                //    PMaxPessoas = 100,
                //    EstadoID = 1,
                //    PDataEstado = DateTime.Today,
                //    PComments = "Espaço com diversas e vários tipos de actividades de lazer, como exibição de cultura, teatro, cinematografia, etc..."
                //},
                //new PontoDeInteresse
                //{
                //    //PontoDeInteresseID
                //    CategoriaID = 6,
                //    PImagem = ReadFile("wwwroot/assets/img/5.jpg"),
                //    PNome = "Teatro Municipal",
                //    PDescricao = "Espaço de divulgação e promoção dos eventos culturais organizados, programados ou apoiados pelo Teatro Municipal da Guarda.",
                //    PEndereco = "R. Batalha Reis 12, 6300-668, Guarda",
                //    PCoordenadas = "https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d12128.537572679055!2d-7.2698275!3d40.5386199!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x29345b6fc74d0998!2sS%C3%A9%20da%20Guarda!5e0!3m2!1sen!2spt!4v1610848692106!5m2!1sen!2spt",
                //    PContacto = 271205240,
                //    PEmail = "geral@tmg.com.pt",
                //    PNumPessoas = 0,
                //    PMaxPessoas = 100,
                //    EstadoID = 1,
                //    PDataEstado = DateTime.Today,
                //    PComments = "Espaço com diversas e vários tipos de actividades de lazer, como exibição de cultura, teatro, cinematografia, etc..."
                //},
                //new PontoDeInteresse
                //{
                //    //PontoDeInteresseID
                //    CategoriaID = 6,
                //    PImagem = ReadFile("wwwroot/assets/img/5.jpg"),
                //    PNome = "Teatro Municipal",
                //    PDescricao = "Espaço de divulgação e promoção dos eventos culturais organizados, programados ou apoiados pelo Teatro Municipal da Guarda.",
                //    PEndereco = "R. Batalha Reis 12, 6300-668, Guarda",
                //    PCoordenadas = "https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d12128.537572679055!2d-7.2698275!3d40.5386199!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x29345b6fc74d0998!2sS%C3%A9%20da%20Guarda!5e0!3m2!1sen!2spt!4v1610848692106!5m2!1sen!2spt",
                //    PContacto = 271205240,
                //    PEmail = "geral@tmg.com.pt",
                //    PNumPessoas = 0,
                //    PMaxPessoas = 100,
                //    EstadoID = 1,
                //    PDataEstado = DateTime.Today,
                //    PComments = "Espaço com diversas e vários tipos de actividades de lazer, como exibição de cultura, teatro, cinematografia, etc..."
                //},
                //new PontoDeInteresse
                //{
                //    //PontoDeInteresseID
                //    CategoriaID = 6,
                //    PImagem = ReadFile("wwwroot/assets/img/5.jpg"),
                //    PNome = "Teatro Municipal",
                //    PDescricao = "Espaço de divulgação e promoção dos eventos culturais organizados, programados ou apoiados pelo Teatro Municipal da Guarda.",
                //    PEndereco = "R. Batalha Reis 12, 6300-668, Guarda",
                //    PCoordenadas = "https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d12128.537572679055!2d-7.2698275!3d40.5386199!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x29345b6fc74d0998!2sS%C3%A9%20da%20Guarda!5e0!3m2!1sen!2spt!4v1610848692106!5m2!1sen!2spt",
                //    PContacto = 271205240,
                //    PEmail = "geral@tmg.com.pt",
                //    PNumPessoas = 0,
                //    PMaxPessoas = 100,
                //    EstadoID = 1,
                //    PDataEstado = DateTime.Today,
                //    PComments = "Espaço com diversas e vários tipos de actividades de lazer, como exibição de cultura, teatro, cinematografia, etc..."
                //}
            );

            dbContext.SaveChanges();
        }










        public static byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes 
            //to read from file.
            //In this case we want to read entire file. 
            //So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);

            return data;
        }
    }
}
