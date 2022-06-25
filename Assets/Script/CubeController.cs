using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    // キューブの移動速度
    private float speed = -12;

    // 消滅位置
    private float deadLine = -10;

    // ぶつかった時の音
    public AudioClip se;

    // キューブのSE
    AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        // AudioSourceコンポーネント取得
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 衝突判定
    /// </summary>
    /// <param name="collision">対面</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            audiosource.PlayOneShot(se);
        }
    }
}
