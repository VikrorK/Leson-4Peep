using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Peep : MonoBehaviour
{
    public Camera camPlayer; //Камера игрока
    public Camera camObj; //Камера объекта которого подсматриваем
    public GameObject imgTexture; //текстура (например замочная скважина)
    public CursorsLook cL; //скрипт включения/отключения контроллера
    private bool _peep=false; //условие подсматриваем или нет
    public float distance=1.5f; //дистанция луча
    public Transform tr; //цель луча для вызова подсказки и дальнейших действий
    public GameObject HelpText; //текстовая подсказка
    public float speedCamera; //скорость вращения камеры
    public float edgesize = 200f; //размер зоны взаимодействия курсора для поворота камеры
    public float maxY=230f; //максимальный угол камеры по Y
    public float minY=130f; //минимальный угол камеры по Y
   
    // Start is called before the first frame update
    void Start()
    {
        camObj.enabled=false; //отключаем камеру объекта
        camPlayer.enabled=true; //включаем камеру игрока
        imgTexture.SetActive(false); //отключаем текстуру
        HelpText.SetActive(false); //отключаем текстовую подсказку
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Ray_start_position = new Vector3(Screen.width/2, Screen.height/2, 0); //устанавливаем где центр экрана
        Ray ray = camPlayer.ScreenPointToRay(Ray_start_position); //пускаем луч из камеры игрока через центр экрана 
        RaycastHit hit; //устанавлием переменную для пересечения луча

        if (Physics.Raycast(ray, out hit, distance)){ //если луч попал в коллайдер на указаном растоянии
           
           if(hit.collider.name==tr.name) //имя коллайдера = имени объекта
           {    
               
            HelpText.SetActive(true); // показываем текстовую подсказку

            if(Input.GetKeyDown(KeyCode.E)&&_peep==true){ // если нажали кнопку E и подсмотр активен
                camObj.enabled=false; //отключаем камеру объекта
                camPlayer.enabled=true; //включаем камеру игрока
                imgTexture.SetActive(false); //отключаем текстуру
                _peep=false; //устанавливаем знчение, что уже не подсматриваем
                cL.CursorTrue(); //отключаем курсор и включаем контроллер
                }

            else if(Input.GetKeyDown(KeyCode.E)&&_peep==false){ // если нажали кнопку E и подсмотр не активен
                camObj.enabled=true; //включаем камеру объекта
                camPlayer.enabled=false; //отключаем камеру игрока
                imgTexture.SetActive(true); //включаем текстуру
                _peep=true; //устанавливаем знчение, что подсматриваем
                
                }
        }
      
    }
      
       else if(_peep==true) // если подсмотр активен
       {
        HelpText.SetActive(true); //активиурем текстувую подсказку
        CameraControl(); //включаем функцию вразения камеры
        cL.CursorFalse(); //отключаем контроллеры и включаем курсор
       
        if(Input.GetKeyDown(KeyCode.E)){ //если нажали кнопку E
                camObj.enabled=false; //отключаем камеру объекта
                camPlayer.enabled=true; //включаем камеру игрока
                imgTexture.SetActive(false); //отключаем текстуру
                _peep=false; //устанавливаем знчение, что уже не подсматриваем
                cL.CursorTrue(); //отключаем курсор и включаем контроллер
            }
        }
        
        else{
            HelpText.SetActive(false);// отключаем подсказку
        }
    }
    
    //функция вращения камеры
    public void CameraControl(){
        if(Input.mousePosition.x > Screen.width - edgesize && camObj.transform.rotation.eulerAngles.y<maxY){
         camObj.transform.Rotate(0,speedCamera*Time.deltaTime,0) ;
        }
        else if(Input.mousePosition.x < edgesize && camObj.transform.rotation.eulerAngles.y>minY){
         camObj.transform.Rotate(0,-speedCamera*Time.deltaTime,0) ;
        }
       
    }
}
