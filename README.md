# Projeto-de-Software---API-PABD
Projeto de software de API da Matéria de Programação com Acesso a Banco de Dados.

# 🎵 Sistema de Gestão de Matrículas para Professor de Música

## 📌 Sobre o Projeto

O **Sistema de Gestão de Matrículas para Professor de Música** é uma API desenvolvida para auxiliar professores de música no gerenciamento completo de alunos, matrículas e evolução pedagógica.

A aplicação permite o cadastro, atualização, edição e remoção de alunos, além de manter um histórico detalhado da evolução de níveis durante o período de aprendizagem. O sistema também gera fichas de aprovação após cada teste de nível realizado pelo aluno.

O objetivo do projeto é oferecer uma solução simples, organizada e eficiente para o acompanhamento acadêmico de estudantes de música.

---

# 🚀 Funcionalidades

## 👨‍🎓 Gerenciamento de Alunos

* Cadastro de alunos
* Atualização de informações
* Edição de dados
* Exclusão de alunos
* Consulta de alunos cadastrados

### Dados cadastrados:

* Nome do aluno
* Idade
* CPF
* Data de início
* Nível do aluno

---

## 📈 Histórico de Evolução

O sistema mantém um histórico completo da evolução dos níveis do aluno, permitindo:

* Registro de mudanças de nível
* Acompanhamento do desempenho
* Visualização da progressão do estudante ao longo do tempo

---

## 📝 Ficha de Aprovação

Após cada teste de nível, o sistema gera automaticamente uma ficha contendo:

* Nome do aluno
* Nível atual
* Resultado do teste
* Data da avaliação

---

# 🛠️ Tecnologias Utilizadas

Exemplo de tecnologias que podem ser utilizadas no projeto:

* C#
* MySQL
* Swagger

---

# 📂 Estrutura do Projeto

```bash
src/
│
├── controllers/
├── datacontexts/
├── dtos/
├── exceptions/
├── models/
├── profiles/
├── services/

```

---

# 📋 Endpoints Principais

## Alunos

| Método | Endpoint    | Descrição       |
| ------ | ----------- | --------------- |
| POST   | /alunos     | Cadastrar aluno |
| GET    | /alunos     | Listar alunos   |
| GET    | /alunos/:id | Buscar aluno    |
| PUT    | /alunos/:id | Atualizar aluno |
| DELETE | /alunos/:id | Remover aluno   |

---

## Histórico de Níveis

| Método | Endpoint            | Descrição                 |
| ------ | ------------------- | ------------------------- |
| POST   | /historico          | Registrar evolução        |
| GET    | /historico/:alunoId | Buscar histórico do aluno |

---

## Ficha de Aprovação

| Método | Endpoint             | Descrição        |
| ------ | -------------------- | ---------------- |
| POST   | /aprovacoes          | Gerar ficha      |
| GET    | /aprovacoes/:alunoId | Consultar fichas |

---

# 🔐 Regras de Negócio

* O CPF do aluno deve ser único.
* Um aluno deve possuir um nível inicial no momento do cadastro.
* Toda alteração de nível deve gerar um registro no histórico.
* Cada teste de nível deve gerar uma ficha de aprovação.

---

# 🎯 Objetivos do Projeto

* Facilitar o gerenciamento de alunos de música
* Automatizar processos administrativos
* Registrar evolução pedagógica
* Melhorar o acompanhamento do desempenho dos alunos

---

# 👨‍💻 Autores

* Lucas Nunes
* Natália Fernandes

---

# ⭐ Considerações Finais

Este projeto foi desenvolvido com foco em organização, escalabilidade e facilidade de manutenção, oferecendo uma solução eficiente para professores de música gerenciarem seus alunos e acompanharem sua evolução acadêmica.

