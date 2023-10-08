Olá.
Ela foi desenvolvida nas tecnologias solicitadas e foi escolhido Blazor para que pudesse desenvolver uma tela.
Utilizei ingestão de dependencia, deixei tudo em interface para manter mais seguro, coloque o hash da senha na camada de service ao inves de deixar mais pra frente para não ficar transitando com a senha sem estar encriptografada.
Coloquei uma controller para que a Api possa ser expandida e receber requisições de outros Clients. Optei pela tecnologia Dapper e tambem por colocar tudo via PROC justamente pela escalabilidade, pela disponibilidade maior que o banco de dados oferece e tambem para manter um padrão de escrita nas consultas.
A senha está no padrão forte.
Não tem as mensagens na tela devido o Blazor não ter esse recurso tão facil, o que me consumiu um tempo e no final decidi não fazer de tudo, apenas de senha fraca. Decidi focar mais no BackEnd neste momento da WebApi.
