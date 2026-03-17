using UnityEngine;

public class Shop : MonoBehaviour
{
    string[] parts =  new string[] {"강제유도","시간정지","공격반사","블랙홀","감속장"};
    private int[] partsPrice = new int[] { 100, 200, 300, 400, 500 };

    public void BuyParts(GameObject button)
    {
        string btnName = button.name;
        int index = int.Parse(btnName);
        switch (index)
        {
            case 0:
                if (MoneySystem.instance.money >= partsPrice[index])
                {
                    Debug.Log("구매한 파츠 : " + parts[index]);
                    MoneySystem.instance.money -= partsPrice[index];
                    Debug.Log("현재 남은 돈 : " + MoneySystem.instance.money);
                }
                break;
            case 1:
                if (MoneySystem.instance.money >= partsPrice[index])
                {
                    Debug.Log("구매한 파츠 : " + parts[index]);
                    MoneySystem.instance.money -= partsPrice[index];
                    Debug.Log("현재 남은 돈 : " + MoneySystem.instance.money);
                }
                break;
            case 2:
                if (MoneySystem.instance.money >= partsPrice[index])
                {
                    Debug.Log("구매한 파츠 : " + parts[index]);
                    MoneySystem.instance.money -= partsPrice[index];
                    Debug.Log("현재 남은 돈 : " + MoneySystem.instance.money);
                }
                break;
            case 3:
                if (MoneySystem.instance.money >= partsPrice[index])
                {
                    Debug.Log("구매한 파츠 : " + parts[index]);
                    MoneySystem.instance.money -= partsPrice[index];
                    Debug.Log("현재 남은 돈 : " + MoneySystem.instance.money);
                }
                break;
            case 4:
                if (MoneySystem.instance.money >= partsPrice[index])
                {
                    Debug.Log("구매한 파츠 : " + parts[index]);
                    MoneySystem.instance.money -= partsPrice[index];
                    Debug.Log("현재 남은 돈 : " + MoneySystem.instance.money);
                }
                break;
            
        }
        
    }
}
