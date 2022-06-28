using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorsLook : MonoBehaviour
{
    public FirstPersonLook fpl;//скрипт управления камерой(вращение игрока)
    public FirstPersonMovement fPM;//скрипт контроллера
    
        //если котроллер и вращение камеры в одном скрипте, то пишем только один скрипт в переменной

    void Start()
    {
         CursorTrue();
    }

    
   //устанавливаем, что курсор отключен, а контроллер и вразение камеры включены
    public void CursorTrue()
    {
            fpl.enabled=true;//включаем вращение камеры
            fPM.enabled=true;//включаем контроллер
            Cursor.visible=false;//отключаем курсор
            Cursor.lockState = CursorLockMode.Locked;//фиксируем курсор в центре экрана
    }
    //устанавливаем, что курсор включен, а контроллер и вразение камеры отключены
     public void CursorFalse()
     {
            fpl.enabled=false;//отключаем вращение камеры
            fPM.enabled=false;//отключаем контроллер
            Cursor.visible=true;//включаем курсор
            Cursor.lockState=CursorLockMode.None;//снимаем фиксацию курсора в центре экрана
    }
}
