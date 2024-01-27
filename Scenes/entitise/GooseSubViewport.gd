extends SubViewport

const GOOSE = preload("res://Scenes/entitise/goose.tscn")
var orignalGlobalPosition: Vector2

func _input(event: InputEvent) -> void:
	if Input.is_action_just_pressed("ui_left"):
		select_left()
	elif Input.is_action_just_pressed("ui_right"):
		select_right()

func select_left() -> void:
	size.x /= 2

func select_right() -> void:
	orignalGlobalPosition = $Goose.global_position
	get_parent().position.x = 1920 / 2
	$Goose.position.x -= 1920
