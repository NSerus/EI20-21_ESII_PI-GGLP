using EI20_21_ESII_PI_GGLP.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EI20_21_ESII_PI_GGLP.Models
{
    public class SeedData
    {
        // Login
        private const string DEFAULT_ADMIN_USER = "admin@ipg.pt";
        private const string DEFAULT_ADMIN_PASSWORD = "Secret123$";

        private const string ROLE_ADMINISTRATOR = "Admin";
        private const string ROLE_PRODUCT_MANAGER = "ProdutManager";
        private const string ROLE_CUSTOMER = "Pessoa";

        internal static async Task SeedDefaultAdminAsync(UserManager<IdentityUser> userManager)
        {
            await EnsureUserIsCreated(userManager, DEFAULT_ADMIN_USER, DEFAULT_ADMIN_PASSWORD, ROLE_ADMINISTRATOR);
        }

        private static async Task EnsureUserIsCreated(UserManager<IdentityUser> userManager, string username, string password, string role)
        {
            IdentityUser user = await userManager.FindByNameAsync(username);

            if (user == null)
            {
                user = new IdentityUser(username);
                await userManager.CreateAsync(user, password);
            }

            if (!await userManager.IsInRoleAsync(user, role))
            {
                await userManager.AddToRoleAsync(user, role);
            }
        }

        internal static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            await EnsureRoleIsCreated(roleManager, ROLE_ADMINISTRATOR);
            await EnsureRoleIsCreated(roleManager, ROLE_PRODUCT_MANAGER);
            await EnsureRoleIsCreated(roleManager, ROLE_CUSTOMER);
        }

        private static async Task EnsureRoleIsCreated(RoleManager<IdentityRole> roleManager, string role)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        internal static async Task SeedDevUsersAsync(UserManager<IdentityUser> userManager)
        {
            await EnsureUserIsCreated(userManager, "admin@ipg.pt", "Secret123$", ROLE_PRODUCT_MANAGER);

            await EnsureUserIsCreated(userManager, "richards@ipg.pt", "Secret123$", ROLE_PRODUCT_MANAGER);
            await EnsureUserIsCreated(userManager, "nserus@ipg.pt", "Secret123$", ROLE_PRODUCT_MANAGER);
            await EnsureUserIsCreated(userManager, "aureopaquete@ipg.pt", "Secret123$", ROLE_PRODUCT_MANAGER);


            await EnsureUserIsCreated(userManager, "jose@gmail.pt", "Secret123$", ROLE_CUSTOMER);
        }

        //internal static void SeedDevData(GGLPDbContext db)
        //{
        //    if (db.Pessoa.Any()) return;

        //    db.Pessoa.Add(new Pessoa
        //    {
        //        //Name = "Mary",
        //        //Email = "mary@ipg.pt"

        //        //PessoaID
        //        PNome = "José Martins",
        //        PContato = 928312764,
        //        PEmail = "jose@gmail.pt",
        //        CTDataNas = new DateTime(1985, 02, 21),
        //        CTNIF = 826496108,
        //        CTLocalidade = "Aveiro",
        //        CTPais = "Portugal",
        //        CTEndereco = "Rua. Manel Antonio, 3648-143, Aveiro",
        //        PComments = "Dono de Restaurante"
        //});

        //    db.SaveChanges();
        //}






        internal static void Populate(GGLPDbContext dbContext)
        {
            PopulateEstado(dbContext);
            PopulateCategoria(dbContext);
            PopulateDia(dbContext);
            PopulatePontoDeInteresse(dbContext);
            PopulatePessoas(dbContext);
            //PopulateAgendamentos(dbContext);
            PopulateHorario(dbContext);
        }

        private static void PopulatePessoas(GGLPDbContext dbContext)
        {
            if (dbContext.Pessoa.Any())
            {
                return;
            }

            dbContext.Pessoa.AddRange(
                new Pessoa
                {
                    //PessoaID
                    PNome = "José Martins",
                    PContato = 928312764,
                    PEmail = "jose@gmail.pt",
                    CTDataNas = new DateTime(1985, 02, 21),
                    CTNIF = 826496108,
                    CTLocalidade = "Aveiro",
                    CTPais = "Portugal",
                    CTEndereco = "Rua. Manel Antonio, 3648-143, Aveiro",
                    PComments = "Dono de Restaurante"
                }
            );
            dbContext.SaveChanges();
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
                },
                new PontoDeInteresse
                {
                    //PontoDeInteresseID
                    CategoriaID = 6,
                    PImagem = ReadFile("wwwroot/assets/img/7.jpg"),
                    PNome = "Cine-Teatro da Guarda",
                    PDescricao = "Encerrado desde 1987, o Cine-Teatro da Guarda é um espaço preponderante que marcou a cultura da cidade da Guarda, funcionou no imaginário coletivo como o “cinema” que nos fez sonhar, mas também como sala de espetáculos onde teatro, revistas e concertos aconteceram.",
                    PEndereco = "Largo de São João 10, 6300 - 772, Guarda",
                    PCoordenadas = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3032.143482353722!2d-7.267870985332678!3d40.53841907935112!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0xd3ce532a97ec3cb%3A0x7a5e91433c530221!2sLargo%20de%20S%C3%A3o%20Jo%C3%A3o%2010%2C%206300-772%20Guarda!5e0!3m2!1sen!2spt!4v1611414041133!5m2!1sen!2spt",
                    PContacto = 271220220,
                    PEmail = "geral@mun-guarda.pt",
                    PNumPessoas = 0,
                    PMaxPessoas = 718,
                    EstadoID = 2,
                    PDataEstado = DateTime.Today,
                    PComments = "Arquitectura cultural, modernista."
                },
                new PontoDeInteresse
                {
                    //PontoDeInteresseID
                    CategoriaID = 7,
                    PImagem = ReadFile("wwwroot/assets/img/8.jpg"),
                    PNome = "Hotel Vanguarda",
                    PDescricao = "Este hotel no centro da Guarda está localizado no ponto mais alto de Portugal, a 1 km de altitude. Tem um restaurante com vista para a Serra da Estrela. Os quartos climatizados do Hotel Vanguarda estão decorados com cores quentes.",
                    PEndereco = "Av. Monsenhor Mendes do Carmo, 6300-586, Guarda",
                    PCoordenadas = "https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d12127.733514192372!2d-7.266209!3d40.543061!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0xbe65a0d863c795ee!2sHotel%20VanGuarda!5e0!3m2!1sen!2spt!4v1611799104773!5m2!1sen!2spt",
                    PContacto = 271208390,
                    PEmail = "centraldereservas@naturaimbhotels.com",
                    PNumPessoas = 0,
                    PMaxPessoas = 300,
                    EstadoID = 1,
                    PDataEstado = DateTime.Today,
                    PComments = "Incluem televisão por cabo e um mini - bar.As casas de banho privativas estão equipadas com produtos de higiene pessoal e algumas casas de banho têm uma banheira de hidromassagem. O Restaurante D. Sancho, no último piso, oferece vistas panorâmicas e comida local num ambiente descontraído. Com vista para as montanhas circundantes, o bar do hotel dispõe de uma lareira acolhedora."
                }
            );

            dbContext.SaveChanges();
        }

        private static void PopulateHorario(GGLPDbContext dbContext)
        {
            if (dbContext.Horario.Any())
            {
                return;
            }

            dbContext.Horario.AddRange(
                new Horario
                {
                    //HorarioID
                    DiaID = 1,
                    PontoDeInteresseID = 2,
                    HInicio = 13,
                    HFim = 14
                },
                new Horario
                {
                    //HorarioID
                    DiaID = 2,
                    PontoDeInteresseID = 2,
                    HInicio = 9,
                    HFim = 10
                }
            );

            dbContext.SaveChanges();
        }




        //private static void PopulateAgendamentos(GGLPDbContext dbContext)
        //{
        //    if (dbContext.Agendamento.Any())
        //    {
        //        return;
        //    }

        //    dbContext.Agendamento.AddRange(
        //        new Agendamento
        //        {
        //            //AgendamentoID
        //            PessoaID = 1,
        //            PontoDeInteresseID = 4,
        //            AData = new DateTime(2021, 02, 12),
        //            AHoraInicio = "21",
        //            AHoraFim = "22",
        //            ANumPessoas = 2
        //        }
        //        //new Agendamento
        //        //{
        //        //    //AgendamentoID
        //        //    PessoaID = 2,
        //        //    PontoDeInteresseID = 3,
        //        //    AData = new DateTime(2020, 12, 12),
        //        //    AHoraInicio = "13",
        //        //    AHoraFim = "17",
        //        //    ANumPessoas = 1
        //        //},
        //        //new Agendamento
        //        //{
        //        //    //AgendamentoID
        //        //    PessoaID = 3,
        //        //    PontoDeInteresseID = 2,
        //        //    AData = new DateTime(2021, 02, 21),
        //        //    AHoraInicio = "15",
        //        //    AHoraFim = "22",
        //        //    ANumPessoas = 4
        //        //},
        //        //new Agendamento
        //        //{
        //        //    //AgendamentoID
        //        //    PessoaID = 3,
        //        //    PontoDeInteresseID = 2,
        //        //    AData = new DateTime(2021, 12, 01),
        //        //    AHoraInicio = "21",
        //        //    AHoraFim = "22",
        //        //    ANumPessoas = 4
        //        //},
        //        //new Agendamento
        //        //{
        //        //    //AgendamentoID
        //        //    PessoaID = 3,
        //        //    PontoDeInteresseID = 2,
        //        //    AData = new DateTime(2020, 12, 20),
        //        //    AHoraInicio = "21",
        //        //    AHoraFim = "22",
        //        //    ANumPessoas = 4
        //        //},
        //        //new Agendamento
        //        //{
        //        //    //AgendamentoID
        //        //    PessoaID = 3,
        //        //    PontoDeInteresseID = 2,
        //        //    AData = new DateTime(2021, 12, 23),
        //        //    AHoraInicio = "21",
        //        //    AHoraFim = "22",
        //        //    ANumPessoas = 4
        //        //},
        //        //new Agendamento
        //        //{
        //        //    //AgendamentoID
        //        //    PessoaID = 3,
        //        //    PontoDeInteresseID = 2,
        //        //    AData = new DateTime(2021, 02, 21),
        //        //    AHoraInicio = "21",
        //        //    AHoraFim = "22",
        //        //    ANumPessoas = 4
        //        //},
        //        //new Agendamento
        //        //{
        //        //    //AgendamentoID
        //        //    PessoaID = 3,
        //        //    PontoDeInteresseID = 2,
        //        //    AData = new DateTime(2021, 02, 21),
        //        //    AHoraInicio = "21",
        //        //    AHoraFim = "22",
        //        //    ANumPessoas = 4
        //        //},
        //        //new Agendamento
        //        //{
        //        //    //AgendamentoID
        //        //    PessoaID = 3,
        //        //    PontoDeInteresseID = 2,
        //        //    AData = new DateTime(2021, 02, 21),
        //        //    AHoraInicio = "21",
        //        //    AHoraFim = "22",
        //        //    ANumPessoas = 4
        //        //},
        //        //new Agendamento
        //        //{
        //        //    //AgendamentoID
        //        //    PessoaID = 3,
        //        //    PontoDeInteresseID = 2,
        //        //    AData = new DateTime(2021, 02, 21),
        //        //    AHoraInicio = "21",
        //        //    AHoraFim = "22",
        //        //    ANumPessoas = 4
        //        //},
        //        //new Agendamento
        //        //{
        //        //    //AgendamentoID
        //        //    PessoaID = 3,
        //        //    PontoDeInteresseID = 2,
        //        //    AData = new DateTime(2021,02,21),
        //        //    AHoraInicio = "21",
        //        //    AHoraFim = "22",
        //        //    ANumPessoas = 4
        //        //}
        //    );

        //    dbContext.SaveChanges();
        //}



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
