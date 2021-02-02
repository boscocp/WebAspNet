using dockerCompose.Models;
using System;
using System.Collections.Generic;
using Npgsql;

namespace PSQLConection.DataAccess
{
    public class DataAccessProvider : IDataAccessProvider
    {
        public void AddPersonRecord(Person person)
        {
            NpgsqlConnection pgsqlConnection = new NpgsqlConnection(GetConnectionString());
            try
            {
                using (pgsqlConnection)
                {
                    pgsqlConnection.Open();
                    string cmdUpdate = String.Format("Insert Into person(name, date_of_birth, cpf, income) values('{0}','{1}','{2}','{3}')", person.Name, person.BirthDate, person.CPF, person.Income);
                    using (NpgsqlCommand cmd = new NpgsqlCommand(cmdUpdate, pgsqlConnection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgsqlConnection.Close();
            }
        }

        public void UpdatePersonRecord(Person person, Person newPerson)
        {
            NpgsqlConnection pgsqlConnection = new NpgsqlConnection(GetConnectionString());
            try
            {
                using (pgsqlConnection)
                {
                    //Abra a conexão com o PgSQL                  
                    pgsqlConnection.Open();
                    string cmdUpdate = String.Format("Update person Set name = '" + newPerson.Name + "', cpf = '" + newPerson.CPF + "', date_of_birth = '" + newPerson.BirthDate + "', income = '" + newPerson.Income + "' WHERE id=" + person.Id);
                    using (NpgsqlCommand cmd = new NpgsqlCommand(cmdUpdate, pgsqlConnection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgsqlConnection.Close();
            }
        }

        public void DeletePersonRecord(Person person)
        {
            NpgsqlConnection pgsqlConnection = new NpgsqlConnection(GetConnectionString());
            try
            {
                using (pgsqlConnection)
                {
                    //Abra a conexão com o PgSQL                  
                    pgsqlConnection.Open();
                    string cmdUpdate = String.Format("Delete From person Where id = " + person.Id);
                    using (NpgsqlCommand cmd = new NpgsqlCommand(cmdUpdate, pgsqlConnection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgsqlConnection.Close();
            }
        }

        public Person GetPersonSingleRecord(Int64 id)
        {
            NpgsqlConnection pgsqlConnection = new NpgsqlConnection(GetConnectionString());
            try
            {
                using (pgsqlConnection)
                {
                    pgsqlConnection.Open();
                    using (NpgsqlCommand cmdSeleciona = new NpgsqlCommand("Select * from person Where id =" + id, pgsqlConnection))
                    {
                        NpgsqlDataReader reader = cmdSeleciona.ExecuteReader();
                        if (reader.Read())
                        {
                            Person person = InicializePerson(reader);
                            return person;
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                pgsqlConnection.Close();
            }
            return null;
        }

        public List<Person> GetPersonRecords()
        {
            List<Person> persons = new List<Person>();
            NpgsqlConnection pgsqlConnection = new NpgsqlConnection(GetConnectionString());
            try
            {
                using (pgsqlConnection)
                {
                    pgsqlConnection.Open();
                    Console.WriteLine("Aqui banco open ");
                    using (NpgsqlCommand cmdSeleciona = new NpgsqlCommand("Select * from person", pgsqlConnection))
                    {
                        Console.WriteLine("Aqui banco open 2");
                        NpgsqlDataReader reader = cmdSeleciona.ExecuteReader();
                        Console.WriteLine("Aqui banco reader ");
                        while (reader.Read())
                        {
                            Console.WriteLine("Aqui banco reader 2");
                            Person person = InicializePerson(reader);
                            persons.Add(person);
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {          
                throw ex;
            }
            finally
            {
                pgsqlConnection.Close();
            }
            return persons;
        }

        private static Person InicializePerson(NpgsqlDataReader reader)
        {
            Person person = new Person();
            person.Name = reader[1].ToString();
            person.CPF = int.Parse(reader[3].ToString());
            person.BirthDate = DateTime.Parse(reader[2].ToString());
            person.Id = Int32.Parse(reader[0].ToString());

            double income = 0;
            Double.TryParse(reader[4].ToString(), out income);
            person.Income = income;
            person.BirthDate = DateTime.Parse(reader[2].ToString());
            return person;
        }

        public string GetConnectionString()
        {
            string config = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            return config;
        }
    }
}