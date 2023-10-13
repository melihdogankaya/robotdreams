using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RobotDreams.API.Controllers
{
<<<<<<< HEAD
    [Route("api/[controller]")]
    [ApiController]
    public class LoopController : ControllerBase
    {
        [HttpGet]
        [Route("for")]
        public IActionResult ExampleFor()
        {
            //for (loop variable ; testing condition ; increment)
            //{
            //
            //}
            //string sayi1 = "1";
            //string sayi2 = "2";
            //string sayi3 = "3";

            List<int> numbers = new();
            for (int i = 1; i <= 100; i++)
            {
                numbers.Add(i);
            }

=======
    public class LoopController : Controller
    {
        [HttpGet]
        [Route("for")]

        public IActionResult ExampleFor()
        {


            List<int> numbers = new();

            for (int i = 0; i <= 100; i++)
            {
                numbers.Add(i);
            }
>>>>>>> mehmetasker
            return Ok(JsonConvert.SerializeObject(numbers));
        }

        [HttpGet]
        [Route("for2")]
<<<<<<< HEAD
        public IActionResult ExampleFor2()
        {
            List<int> numbers = new();

            for (int i = 1; i <= 100; i += 2)
            {
                numbers.Add(i);
            }

=======

        public IActionResult ExampleFor2()
        {


            List<int> numbers = new();

            for (int i = 0; i <= 100; i += 2)
            {
                numbers.Add(i);
            }
>>>>>>> mehmetasker
            return Ok(JsonConvert.SerializeObject(numbers));
        }

        [HttpGet]
        [Route("while")]
<<<<<<< HEAD
        public IActionResult ExampleWhile()
        {
            int i = 1;
            List<int> numbers = new();

            //while(condition)
=======

        public IActionResult ExampleWhile()
        {

            int i = 1;
            List<int> numbers = new();

            //while(Koşul)
>>>>>>> mehmetasker
            //{

            //}

            while (i <= 100)
            {
                numbers.Add(i);
                i++;
            }
<<<<<<< HEAD

=======
>>>>>>> mehmetasker
            return Ok(JsonConvert.SerializeObject(numbers));
        }

        [HttpGet]
        [Route("foreach")]
<<<<<<< HEAD
        public IActionResult ExampleForeach()
        {
            List<int> result = new();
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //for (int i = 0; i < array.Length; i++)
            //{
            //    result.Add(array[i]);
            //}

            foreach (var i in array)
=======

        public IActionResult ExampleForeach()
        {
            List<int> result = new();
            //foreach(data_type var_name in collection_var)
            //{

            //}

            int[] list = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //for(int i = 0; i < list.Length; i++)
            ////{
            //    result.Add(list[i]);
            //}

            foreach (var i in list)
>>>>>>> mehmetasker
            {
                result.Add(i);
            }

            return Ok(JsonConvert.SerializeObject(result));
        }

        [HttpGet]
        [Route("dowhile")]
<<<<<<< HEAD
=======

>>>>>>> mehmetasker
        public IActionResult ExampleDoWhile()
        {
            int x = 21;
            int y = 21;

            List<int> result = new();
<<<<<<< HEAD

            do
            {
                result.Add(x);
                x++;
            } while (x < 20);
            

            while (y < 20)
            {
                result.Add(y);
                y++;
            }

            //do
            //{
            //}while(condition)

            return Ok(JsonConvert.SerializeObject(result));
        }

        [HttpGet]
        [Route("break")]
        public IActionResult ExampleBreak()
        {
            List<int> result = new();
            for (int i = 1; i <= 10; i++)
            {
                if(i == 5)
=======
            do
            {
                result.Add(x);
            } while (x < 20);


            //do
            //{
            //} while (Koşul);
            return Ok();
        }

        [HttpGet]
        [Route("Break")]
        public IActionResult ExampleBreak()
        {
            List<int> result = new();
            for (int i = 0; i <= 10; i++)
            {
                if (i == 5)
>>>>>>> mehmetasker
                {
                    break;
                }
                result.Add(i);
            }
<<<<<<< HEAD
=======

>>>>>>> mehmetasker
            return Ok(JsonConvert.SerializeObject(result));
        }

        [HttpGet]
<<<<<<< HEAD
        [Route("continue")]
        public IActionResult ExampleContinue()
        {
            List<int> result = new();
            for (int i = 1; i <= 10; i++)
=======
        [Route("Continues")]
        public IActionResult ExampleContinues()
        {
            List<int> result = new();
            for (int i = 0; i <= 10; i++)
>>>>>>> mehmetasker
            {
                if (i == 5)
                {
                    continue;
                }
                result.Add(i);
            }
<<<<<<< HEAD
            return Ok(JsonConvert.SerializeObject(result));
        }

        [HttpGet]
        [Route("infinite")]
        public IActionResult ExampleInfiniteLoop()
        {
            //for (; ; )
            //{

            //}

            //while(1==1)
            //{

            //}

            //do
            //{

            //} while (1 == 1);

            return Ok();
        }
=======

            return Ok(JsonConvert.SerializeObject(result));
        }
>>>>>>> mehmetasker
    }
}
