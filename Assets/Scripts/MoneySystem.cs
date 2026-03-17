using UnityEngine;

public class MoneySystem : MonoBehaviour
{
    //싱글톤 생성
        public static MoneySystem instance { get; private set; }
        public int money = 0;
        
        void Awake()
        {
            if (instance == null)
            {
                instance = this; 
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
}
