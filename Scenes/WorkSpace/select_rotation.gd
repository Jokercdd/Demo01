extends CanvasLayer


var limbArray: Array = [
	preload("res://Scenes/entitise/limbs/leg_f.tscn"),
	preload("res://Scenes/entitise/limbs/wing_f.tscn"),
	preload("res://Scenes/entitise/limbs/leg_b.tscn"),
	preload("res://Scenes/entitise/limbs/wing_b.tscn"),
	preload("res://Scenes/entitise/limbs/head.tscn")
]
var selected: bool = false
var addedTimes: int = 0
var selected_limb: Node2D
@onready var v_scroll_bar: VScrollBar = $VScrollBar
var roll_not_add: int = -1
var click_mouse_position: Vector2 = Vector2.ZERO

func _ready() -> void:
	v_scroll_bar.value = 50
	
func _process(delta: float) -> void:
	if selected:
		caculate()
	
func caculate() -> void:
	var rot: float = (v_scroll_bar.value - 50) / 50 * PI
	selected_limb.rotation = rot

func _input(event: InputEvent) -> void:
	if selected:
		return
	if event is InputEventMouseButton:
		if event.button_index == 1:
			if event.is_pressed():
				if roll_not_add == 1:
					for limb in $Goose.get_children():
						if limb.is_in_group("limbs") and limb.mouse_in_area:
							selected = true
							limb.selected = true
							selected_limb = limb
							limb.modulate = Color(1,0,0)
				elif roll_not_add == 0 and addedTimes < 3:
					addedTimes += 1
					click_mouse_position = get_parent().get_mouse_position()
					add_limb()

func add_limb() -> void:
	var limbIndex: int = randi_range(0, limbArray.size() - 1)
	var limbFile = limbArray[limbIndex]
	var limb: Node2D = limbFile.instantiate()
	var direction: Vector2 = (click_mouse_position - $Goose.position).normalized()
	limb.add_to_group("limbs")
	match limbIndex:
		0:
			limb.z_index = 2
			limb.rotation = direction.angle() - PI / 4 - PI / 6
			limb.position += 11 * direction
		1:
			limb.z_index = 2
			limb.rotation = direction.angle() + PI / 2 - PI / 6
			#limb.position += 50 * direction
		2:
			limb.z_index = 0
			limb.rotation = direction.angle() - PI / 4 - PI / 6
			limb.position += 11 * direction
		3:
			limb.z_index = 0
			limb.rotation = direction.angle() + PI / 2 - PI / 6
			#limb.position += 50 * direction
		4:
			limb.rotation = direction.angle() + PI / 2 + PI / 4
			limb.position -= 10 * direction
	$Goose.add_child(limb)

func _on_roll_button_pressed() -> void:
	$VScrollBar.show()
	roll_not_add = 1
	
func _on_add_button_pressed() -> void:
	roll_not_add = 0
