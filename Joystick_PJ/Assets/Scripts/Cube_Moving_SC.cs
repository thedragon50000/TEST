using UnityEngine;
using System.Collections;

public class Cube_Moving_SC : MonoBehaviour {
    public Animator target;
    public float speed = 2.5f;
    public AnimatorParameters parameters;
    private Coroutine cououtine;

    private Vector3 direction;

    private IEnumerator Move(){

        while(true){

            this.target.transform.position += this.direction * Time.deltaTime * this.speed;

            this.target.SetFloat(this.parameters.horizotal , this.direction.x);
            this.target.SetFloat(this.parameters.vertical , this.direction.y);

            yield return null;
        }
    }

    public void BeginMove(){

        this.target.SetBool(this.parameters.moving, true);
        this.cououtine = StartCoroutine(this.Move());
    }

    public void EndMove(){

        this.target.SetBool(this.parameters.moving, false);
        StopCoroutine(this.cououtine);
    }

    public void UpdateDirection(Vector3 direction){

        this.direction = direction;
    }

    [System.Serializable]
    public class AnimatorParameters{
        public string moving;
        public string horizotal;
        public string vertical;
    }
}