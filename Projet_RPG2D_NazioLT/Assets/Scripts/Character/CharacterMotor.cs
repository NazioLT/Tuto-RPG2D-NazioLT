using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Vector2 velocity = Vector2.zero;
    private Direction direction = 0;


    private InputsManager inputs;
    private Animator anim;
    private GameManager manager;

    private void Start()
    {
        manager = GameManager.GetInstance();
        inputs = InputsManager.instance;
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector2 _moveValue = inputs.GetMovingInputs().normalized;
        _moveValue = ChooseDirection(_moveValue);

        velocity = _moveValue * speed;

        transform.position += new Vector3(velocity.x * Time.fixedDeltaTime, velocity.y * Time.fixedDeltaTime, 0);

        //Animation
        anim.SetInteger(GameInfos.DIRECTION_ANIM_KEY, (int)direction);
    }

    private Vector2 ChooseDirection(Vector2 _value)
    {
        Vector2 _result = Mathf.Abs(_value.x) >= Mathf.Abs(_value.y) ? new Vector2(_value.x, 0) : new Vector2(0, _value.y);

        direction = SetDirection(_result);
        return _result;
    }

    private Direction SetDirection(Vector2 _vector)
    {
        if (_vector.x > 0) return Direction.East;
        if (_vector.x < 0) return Direction.West;

        if (_vector.y > 0) return Direction.North;
        if (_vector.y < 0) return Direction.South;

        return Direction.None;
    }
}