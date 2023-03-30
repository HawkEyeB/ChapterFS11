using ChapterFS11.Controllers;
using ChapterFS11.Interfaces;
using ChapterFS11.Models;
using ChapterFS11.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.IdentityModel.Tokens.Jwt;

namespace TesteIntegraçãoo
{
    public class LoginControllerTeste
    {
        [Fact]
        public void TeLoginController_Retornar_Usuario_Invalido()
        {
            // Arrange - Preparação
            var repositoryEspelhado = new Mock<IUsuarioRepository>();
            repositoryEspelhado.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns((Usuario)null);

            var controller = new LoginController(repositoryEspelhado.Object);

            LoginViewModel dadosUsuario = new LoginViewModel();
            dadosUsuario.email = "batata@email.com";
            dadosUsuario.senha = "batata";


            // Act - Ação
            var resultado = controller.Login(dadosUsuario);


            // Assert - Verificação
            Assert.IsType<UnauthorizedObjectResult>(resultado);
        }

        [Fact]

        public void LoginController_Retornar_Token()
        {
            // Arrange - Preparação
            Usuario usuarioRetornado = new Usuario();
            usuarioRetornado.Email = "email@email.com";
            usuarioRetornado.Senha = "1234";
            usuarioRetornado.Tipo = "0";
            usuarioRetornado.Id = 1;

            var repositoryEspelhado = new Mock<IUsuarioRepository>();
            repositoryEspelhado.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(usuarioRetornado);

            LoginViewModel dadosUsuario = new LoginViewModel();
            dadosUsuario.email = "batata@email.com";
            dadosUsuario.senha = "batata";

            var controller = new LoginController(repositoryEspelhado.Object);

            string issuerValido = "chapter.webapi";

            // Act - Ação
            OkObjectResult resultado = (OkObjectResult)controller.Login(dadosUsuario);

            var tokenString = resultado.Value.ToString().Split(' ')[3];

            var jwHandler = new JwtSecurityTokenHandler();
            var tokenJwt = jwHandler.ReadJwtToken(tokenString);


            // Assert - Verificação
            Assert.Equal(issuerValido, tokenJwt.Issuer);
        }
    }
}