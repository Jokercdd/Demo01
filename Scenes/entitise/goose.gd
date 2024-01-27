extends Node2D

var key_pressed: bool = false
var image_resource: Dictionary = {
	"body" : "res://Resources/image/idle_images/body.png",
	"head" : "res://Resources/image/idle_images/head.png",
	"leg_b" : "res://Resources/image/idle_images/leg_B.png",
	"leg_f" : "res://Resources/image/idle_images/leg_F.png",
	"wing_f" : "res://Resources/image/idle_images/wings_F.png",
	"wing_b" : "res://Resources/image/idle_images/wing_B.png"
}

func _input(event: InputEvent) -> void:
	if Input.is_action_pressed("move_right"):
		position.x += 5
	if Input.is_action_pressed("move_left"):
		position.x -= 5
	if Input.is_action_pressed("move_down"):
		position.y += 5
	if Input.is_action_pressed("move_up"):
		position.y -= 5

## rot为旋转角度，调用该函数则被选择的物体设置为rot角度
func select_body_roll(rot: float) -> void:
	for child in get_children():
		if child.selected:
			child.rotation = rot
