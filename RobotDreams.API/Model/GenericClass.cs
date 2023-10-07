namespace RobotDreams.API.Model
{
    public class GenericClass<T>
    {
        public T ProcessData(string data)
        {
            try
            {
                // Veriyi işleme işlemi burada yapılabilir.
                // Örnek olarak bir tür dönüşüm yapalım:
                T result = (T)Convert.ChangeType(data, typeof(T));
                return result;
            }
            catch (FormatException ex)
            {
                // Veri uyumsuzluğu hatası
                throw new FormatException("Veri uyumsuzluğu hatası: " + ex.Message);
            }
            catch (InvalidCastException ex)
            {
                // Dönüşüm hatası
                throw new InvalidCastException("Dönüşüm hatası: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Diğer hatalar için genel bir hata mesajı
                throw new Exception("Bilinmeyen bir hata oluştu: " + ex.Message);
            }
        }
    }
}
