﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RobotDreams.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoopController : ControllerBase
    {

        [HttpGet]
        [Route("For")]
        public IActionResult Loop_For_1()
        {
            List<int> number = new();
            for (int i = 0; i < 100; i++)
            {
                number.Add(i);
            }
            return Ok(JsonConvert.SerializeObject(number));
        }
        [HttpGet]
        [Route("For_2")]
        public IActionResult Loop_for_2()
        {
            List<int> tekSayilar = new();
            for (int i = 0; i <= 100; i++)
            {
                if (i % 2 == 1)
                    tekSayilar.Add(i);
            }
            return Ok(JsonConvert.SerializeObject(tekSayilar));
        }
        [HttpGet]
        [Route("While")]
        public IActionResult Loop_While_1()
        {
            List<int> number = new();
            int i = 0;
            while (i < 100)
            {
                number.Add(i);
                i++;
            }
            return Ok(JsonConvert.SerializeObject(number));

        }
        [HttpGet]
        [Route("Foreach")]
        public IActionResult Loop_Foreach()
        {

            List<int> number = new();
            List<int> number2 = new();
            for (int i = 0; i < 10; i++)
            {
                number.Add(i);
            }

            foreach (var i in number)
            {
                if (i % 2 == 0)
                    number2.Add(i);
            }

            return Ok(number2);

        }

        [HttpGet]
        [Route("Do-While")]
        public IActionResult DoWhile()
        {

            List<int> numbers = new();
            int i = 3;
            do
            {
                numbers.Add(i);
                i++;


            } while (i <= 2);



            return Ok(numbers);
        }

        [HttpGet]
        [Route("Break")]
        public IActionResult Break()
        {
            List<int> numbers = new();
            for (int i = 0; i < 10; i++)
            {
                if (i == 4)
                    break;
                numbers.Add(i);
            }
            return Ok(JsonConvert.SerializeObject(numbers));
        }

        [HttpGet]
        [Route("Continue")]
        public IActionResult Continue()
        {
            List<int> numbers = new();
            int i = 3;

            while (i <= 14)


            {
                i++;
                if (i == 10)
                    continue;
                numbers.Add(i);

            }
            return Ok(JsonConvert.SerializeObject(numbers));
        }

        [HttpGet]
        [Route("Disardan veri alma- if")]
        public IActionResult DisaridanVeriAlma(string veri)
        {
            string result;

            if (veri.StartsWith("O"))
                result = "O ile baslamaktadir";
            else
            {
                result = "O ile BASLAMAMAKTADIR";
            }

            return Ok(result);
        }
        [HttpGet]
        [Route("Switch - Case")]
        public IActionResult SwitchCase(string TeamCode)
        {

            string result;
            switch (TeamCode)
            {
                case "BJK": result = "Besiktas";
                    break;

                case "GS": result = "Galatasaray";
                    break;
                case "FB": result = "Fenerbahce";
                    break;

                default: result = "Hicbiri degil";
                    break;
            }
            return Ok(result);
        }

    }
}

